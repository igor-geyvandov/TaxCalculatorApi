using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.Services.Dtos
{
    /// <summary>
    /// DTO models for TaxJar API request params and response data.
    /// </summary>
    public class TaxJarTaxRateRequestDto
    {
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
