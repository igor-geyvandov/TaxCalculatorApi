using System.Collections.Generic;

namespace TaxService.Entities
{
    /// <summary>
    /// OrderTax entity used to interact with Services.
    /// </summary>
    public class OrderTax
    {  
        public Tax Tax { get; set; }
    }

    public class Tax
    {
        public float OrderTotalAmount { get; set; }
        public float Shipping { get; set; }
        public float TaxableAmount { get; set; }
        public float AmountToCollect { get; set; }
        public float Rate { get; set; }
        public bool HasNexus { get; set; }
        public bool FreightTaxable { get; set; }
        public string TaxSource { get; set; }
        public Jurisdiction Jurisdictions { get; set; }
        public Breakdown Breakdown { get; set; }
    }

    public class Jurisdiction
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string City { get; set; }
    }

    public class Breakdown
    {
        public float TaxableAmount { get; set; }
        public float TaxCollectable { get; set; }
        public float CombinedTaxRate { get; set; }
        public float StateTaxableAmount { get; set; }
        public float StateTaxRate { get; set; }
        public float StateTaxCollectable { get; set; }
        public float CountyTaxableAmount { get; set; }
        public float CountyTaxRate { get; set; }
        public float CountyTaxCollectable { get; set; }
        public float CityTaxableAmount { get; set; }
        public float CityTaxRate { get; set; }
        public float CityTaxCollectable { get; set; }
        public float SpecialDistrictTaxableAmount { get; set; }
        public float SpecialTaxRate { get; set; }
        public float SpecialDistrictTaxCollectable { get; set; }
        public Shipping Shipping { get; set; }
        public List<LineItem> LineItems { get; set; }
    }

    public class Shipping
    {
    }
}
