using AutoMapper;
using System.Threading.Tasks;
using TaxService.Entities;
using TaxService.Helpers;
using TaxService.MappingProfiles;
using TaxService.Services.Interfaces;

namespace TaxService.Services
{
    /// <summary>
    /// TaxJar implementation for an external tax service.
    /// </summary>
    public class AnotherCalculatorService : ITaxCalculatorService
    {
        private readonly IMapper _mapper;

        public string Name { get; set; }

        public AnotherCalculatorService()
        {
            Name = "AnotherService";
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DefaultMappingProfile>());
            _mapper = new Mapper(config);
        }

        public async Task<TaxRate> GetTaxRateForLocation(Location location)
        {
            return new TaxRate();            
        }

        public async Task<OrderTax> GetSalesTaxForOrder(Order order)
        {
            return new OrderTax();
        }
    }
}
