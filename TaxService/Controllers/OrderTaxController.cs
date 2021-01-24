using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TaxService.Entities;
using TaxService.Exceptions;
using TaxService.Models;
using TaxService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TaxService.Helpers;
using Microsoft.Extensions.Options;

namespace TaxService.Controllers
{
    /// <summary>
    /// Controller for processing Tax Rate requests.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrderTaxController : ControllerBase
    {
        private readonly ILogger<TaxRateController> _logger;
        private readonly ITaxCalculatorService _taxCalculatorService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public OrderTaxController(ILogger<TaxRateController> logger, IMapper mapper, ITaxCalculatorService service, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _mapper = mapper;
            _taxCalculatorService = service;
            _appSettings = appSettings.Value;
        }       

        /// <summary>
        /// Returns all taxes due for a specified order.
        /// </summary>
        /// <param name="taxRateRequestDto"></param>
        /// <returns></returns>
        [HttpPost(Name = nameof(GetOrderTax))]
        public async Task<IActionResult> GetOrderTax([FromBody] OrderTaxRequestDto orderTaxRequestDto)
        {
            Order order = _mapper.Map<Order>(orderTaxRequestDto);
            var orderTax = await _taxCalculatorService.GetSalesTaxForOrder(order);
            if (orderTax == null)
            {
                _logger.LogDebug(string.Format("Could not calculate taxes for this order from {0}", order.FromCountry));
                throw new OrderTaxNotFoundException(order.CustomerId);
            }
            return Ok(_mapper.Map<OrderTaxResponseDto>(orderTax));
        }
    }
}
