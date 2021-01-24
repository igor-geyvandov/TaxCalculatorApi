using System.Threading.Tasks;
using TaxService.Entities;

namespace TaxService.Services.Interfaces
{
    /// <summary>
    /// Interface for different external tax services such as TaxJar.
    /// </summary>
    public interface ITaxCalculatorService
    {
        string Name { get; set; }
        Task<TaxRate> GetTaxRateForLocation(Location location);
        Task<OrderTax> GetSalesTaxForOrder(Order order);
    }
}
