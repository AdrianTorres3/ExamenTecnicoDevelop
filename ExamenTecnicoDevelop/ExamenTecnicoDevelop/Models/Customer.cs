using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace ExamenTecnicoDevelop.Models
{
    public class Customer
    {
        [JsonProperty("customerId")]
        public string? CustomerId {  get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("phoneHome")]
        public string? PhoneHome {  get; set; }
        [JsonProperty("phoneMobile")]
        public string? PhoneMobile { get; set; }
        [JsonProperty("addresses")]
        public List<Address>? Addresses { get; set; }
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
    }
}
