using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxService.Models
{
    /// <summary>
    /// DTO models for Web API request params and response data.
    /// </summary>
    public class OrderTaxRequestDto 
    {  
        public string FromCountry { get; set; }
        public string FromZip { get; set; }
        public string FromState { get; set; }
        public string FromCity { get; set; }
        public string FromStreet { get; set; }
        [Required]
        public string ToCountry { get; set; }
        public string ToZip { get; set; }
        public string ToState { get; set; }
        public string ToCity { get; set; }
        public string ToStreet { get; set; }
        public float Amount { get; set; }
        [Required]
        public float Shipping { get; set; }
        public string CustomerId { get; set; }
        public string ExemptionType { get; set; }
        public List<AddressDto> NexusAddresses { get; set; }
        public List<LineItemDto> LineItems { get; set; }
    }

    public class AddressDto
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

    public class LineItemDto
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public string ProductTaxCode { get; set; }
        public float UnitPrice { get; set; }
        public float Discount { get; set; }
    }
}