using Newtonsoft.Json;
using TaxService.Helpers;

namespace TaxService.Services.Dtos
{
    /// <summary>
    /// DTO models for TaxJar API request params and response data.
    /// </summary>
    [JsonConverter(typeof(JsonPathConverter))]
    public class TaxJarTaxRateResponseDto
    {
        [JsonProperty("rate.zip")]
        public string Zip { get; set; }

        [JsonProperty("rate.country")]
        public string Country { get; set; }

        [JsonProperty("rate.country_rate")] 
        public float CountryRate { get; set; }

        [JsonProperty("rate.state")]
        public string State { get; set; }

        [JsonProperty("rate.state_rate")]
        public float StateRate { get; set; }

        [JsonProperty("rate.county")]
        public string County { get; set; }

        [JsonProperty("rate.county_rate")]
        public float CountyRate { get; set; }

        [JsonProperty("rate.city")]
        public string City { get; set; }

        [JsonProperty("rate.city_rate")]
        public float CityRate { get; set; }

        [JsonProperty("rate.combined_district_rate")]
        public float CombinedDistrictRate { get; set; }

        [JsonProperty("rate.combined_rate")]
        public float CombinedRate { get; set; }

        [JsonProperty("rate.freight_taxable")]
        public bool IsFreightTaxable { get; set; }
    }
}
