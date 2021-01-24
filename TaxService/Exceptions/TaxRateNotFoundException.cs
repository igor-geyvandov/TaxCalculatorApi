using System;

namespace TaxService.Exceptions
{
    /// <summary>
    /// Custom API exception thrown when TaxRate data is not returned from Services.
    /// </summary>
    [Serializable]
    public class TaxRateNotFoundException : Exception
    {
        public TaxRateNotFoundException()
        {
        }

        public TaxRateNotFoundException(string zip)
            : base(String.Format("Tax rate not found for zip code {0}", zip))
        {
        }
    }
}
