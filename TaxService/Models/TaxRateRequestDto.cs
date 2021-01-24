using System.ComponentModel.DataAnnotations;

namespace TaxService.Models
{
    /// <summary>
    /// DTO models for Web API request params and response data.
    /// </summary>
    public class TaxRateRequestDto
    {  
        public string Country { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5)]        
        public string Zip { get; set; }
        
        public string State { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
    }
}
