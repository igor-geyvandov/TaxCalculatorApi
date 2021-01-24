using System.Collections.Generic;

namespace TaxService.Entities
{
    /// <summary>
    /// Order entity used to interact with Services.
    /// </summary>
    public class Order
    {  
        public string FromCountry { get; set; }
        public string FromZip { get; set; }
        public string FromState { get; set; }
        public string FromCity { get; set; }
        public string FromStreet { get; set; }
        public string ToCountry { get; set; }
        public string ToZip { get; set; }
        public string ToState { get; set; }
        public string ToCity { get; set; }
        public string ToStreet { get; set; }
        public float Amount { get; set; }
        public float Shipping { get; set; }
        public string CustomerId { get; set; }
        public string ExemptionType { get; set; }
        public List<Address> NexusAddresses { get; set; }
        public List<LineItem> LineItems { get; set; }
    }

    public class Address
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

    public class LineItem
    {
        public string Id { get; set; }
        public string Quantity { get; set; }
        public string ProductTaxCode { get; set; }
        public float UnitPrice { get; set; }
        public float Discount { get; set; }
    }
}
