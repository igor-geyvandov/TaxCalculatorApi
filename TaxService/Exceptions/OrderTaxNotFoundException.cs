using System;

namespace TaxService.Exceptions
{
    /// <summary>
    /// Custom API exception thrown when OrderTax data is not returned from Services.
    /// </summary>
    [Serializable]
    public class OrderTaxNotFoundException : Exception
    {
        public OrderTaxNotFoundException()
        {
        }

        public OrderTaxNotFoundException(string orderNumber)
            : base(String.Format("Could not calculate taxes for this order {0}", orderNumber))
        {
        }
    }
}
