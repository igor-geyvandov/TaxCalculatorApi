using System.Collections.Generic;

namespace TaxService.Models
{
    /// <summary>
    /// DTO models for Web API request params and response data.
    /// </summary>
    public class OrderTaxResponseDto
    {  
        public TaxDto Tax { get; set; }
    }

    public class TaxDto
    {
        public float OrderTotalAmount { get; set; }
        public float Shipping { get; set; }
        public float TaxableAmount { get; set; }
        public float AmountToCollect { get; set; }
        public float Rate { get; set; }
        public bool HasNexus { get; set; }
        public bool FreightTaxable { get; set; }
        public string TaxSource { get; set; }
        public JurisdictionDto Jurisdictions { get; set; }
        public BreakdownDto Breakdown { get; set; }
    }

    public class JurisdictionDto
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string City { get; set; }
    }

    public class BreakdownDto
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
        public ShippingDto Shipping { get; set; }
        public List<LineItemDto> LineItems { get; set; }
    }

    public class ShippingDto
    {
    }
}
