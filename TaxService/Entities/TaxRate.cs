﻿namespace TaxService.Entities
{
    /// <summary>
    /// TaxRate entity used to interact with Services.
    /// </summary>
    public class TaxRate
    {
        public string Zip { get; set; }
        public string Country { get; set; }
        public float CountryRate { get; set; }
        public string State { get; set; }
        public float StateRate { get; set; }
        public string County { get; set; }
        public float CountyRate { get; set; }
        public string City { get; set; }
        public float CityRate { get; set; }
        public float CombinedDistrictRate { get; set; }
        public float CombinedRate { get; set; }
        public bool IsFreightTaxable { get; set; }
    }
}
