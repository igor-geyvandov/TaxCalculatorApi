using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TaxService.Entities;
using TaxService.Helpers;
using TaxService.MappingProfiles;
using TaxService.Services.Dtos;
using TaxService.Services.Interfaces;

namespace TaxService.Services
{
    /// <summary>
    /// TaxJar implementation for an external tax service.
    /// </summary>
    public class TaxJarCalculatorService : ITaxCalculatorService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public string Name { get; set; }

        public TaxJarCalculatorService()
        {
            Name = "TaxJarService";

            _httpClient = new HttpClient();          
            _httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", "5da2f821eee4035db4771edab942a4cc"));

            var config = new MapperConfiguration(cfg => cfg.AddProfile<DefaultMappingProfile>());
            _mapper = new Mapper(config);
        }

        public async Task<TaxRate> GetTaxRateForLocation(Location location)
        {
            TaxRate taxRate = null;

            var taxJarTaxRateRequestDto = _mapper.Map<TaxJarTaxRateRequestDto>(location);
            var queryString = ObjectToQueryStringConverter.Convert(taxJarTaxRateRequestDto, new string[] { "Zip" });
            var requestUri = BuildUriForApiCall("https://api.taxjar.com/v2", "rates /" + taxJarTaxRateRequestDto.Zip, queryString);   
            var response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var taxJarTaxRateResponseDto = JsonConvert.DeserializeObject<TaxJarTaxRateResponseDto>(responseJson);
                taxRate = _mapper.Map<TaxRate>(taxJarTaxRateResponseDto);
            }
            return taxRate;            
        }

        public async Task<OrderTax> GetSalesTaxForOrder(Order order)
        {
            OrderTax orderTax = null;

            var taxJarOrderTaxRequestDto = _mapper.Map<TaxJarOrderTaxRequestDto>(order);
            var buffer = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(taxJarOrderTaxRequestDto));
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var requestUri = BuildUriForApiCall("https://api.taxjar.com/v2", "taxes");     
            var response = await _httpClient.PostAsync(requestUri, byteContent);
            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var taxJarOrderTaxResponseDto = JsonConvert.DeserializeObject<TaxJarOrderTaxResponseDto>(responseJson);
                orderTax = _mapper.Map<OrderTax>(taxJarOrderTaxResponseDto);
            }
            return orderTax;
        }

        private string BuildUriForApiCall(string baseUrl = "", string path = "", string queryString = "")
        {
            string url = baseUrl + (string.IsNullOrEmpty(path) ? "" : "/") + path;
            url += (string.IsNullOrEmpty(queryString) ? "" : "?") + queryString;
            return url;
        }
    }
}
