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
using Microsoft.Extensions.Options;
using TaxService.Helpers;

namespace TaxService.Controllers
{
    /// <summary>
    /// Controller for processing Tax Rate requests.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TaxRateController : ControllerBase
    {
        private readonly ILogger<TaxRateController> _logger;
        private readonly ITaxCalculatorService _taxCalculatorService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public TaxRateController(ILogger<TaxRateController> logger, IMapper mapper, ITaxCalculatorService service, IOptions<AppSettings> appSettings)
        {   
            _logger = logger;
            _mapper = mapper;
            _taxCalculatorService = service;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Returns tax rate for a specified location.
        /// </summary>
        /// <param name="taxRateRequestDto"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetTaxRate))]
        public async Task<IActionResult> GetTaxRate([FromQuery] TaxRateRequestDto taxRateRequestDto)
        {
            var taxRate = await _taxCalculatorService.GetTaxRateForLocation(new Location { Zip = taxRateRequestDto.Zip });
            if (taxRate == null)
            {
                _logger.LogDebug(string.Format("Tax rate not found for zip {0}", taxRateRequestDto.Zip));
                throw new TaxRateNotFoundException(taxRateRequestDto.Zip);                
            }
            return Ok(_mapper.Map<TaxRateResponseDto>(taxRate));
        }
    }
}
