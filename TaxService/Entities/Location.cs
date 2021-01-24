namespace TaxService.Entities
{
    /// <summary>
    /// Location entity used to interact with Services.
    /// </summary>
    public class Location
    {  
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
