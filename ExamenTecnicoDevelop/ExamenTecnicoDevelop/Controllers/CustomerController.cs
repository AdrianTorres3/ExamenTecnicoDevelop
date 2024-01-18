using ExamenTecnicoDevelop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;

namespace ExamenTecnicoDevelop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        [Route("customerInfo")]
        public async Task<Customer> CustomerInfo()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest()
            {
                Resource = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer",
                Method = Method.Get,
                
            };
            restRequest.AddHeader("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);

            if (restResponse == null) { return new Customer(); }
            if (restResponse.Content == null)
            {
                return new Customer();
            }


            string? customerResponseAux = JsonConvert.DeserializeObject(restResponse.Content).ToString();

            if (customerResponseAux == null) { return new Customer(); }
            Customer? customerResponse = JsonConvert.DeserializeObject<Customer>(customerResponseAux);


            if (customerResponse == null)
            {
                return new Customer();
            }
            return customerResponse;
        }
        [HttpGet]
        [Route("adressesOrdenAlfabeticoYFechaCreacion")]
        public async Task<List<Address>> AddressOrdenAlfabeticoYFechaCreacion()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest()
            {
                Resource = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer",
                Method = Method.Get,

            };
            restRequest.AddHeader("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);

            if (restResponse == null) { return new List<Address>(); }
            if (restResponse.Content == null)
            {
                return new List<Address>();
            }


            string? customerResponseAux = JsonConvert.DeserializeObject(restResponse.Content).ToString();

            if (customerResponseAux == null) { return new List<Address>(); }
            Customer? customerResponse = JsonConvert.DeserializeObject<Customer>(customerResponseAux);
            if(customerResponse == null) { return new List<Address>(); }
            if(customerResponse.Addresses == null) { return new List<Address>(); }
            List<Address> addressResultAux = customerResponse.Addresses.ToList();
            List<Address> addressResult = addressResultAux.OrderBy(address => address.Address1).ThenByDescending(address=>address.CreationDate).ToList();
            if (addressResult == null)
            {
                return new List<Address>();
            }
            return addressResult;
        }

        [HttpGet]
        [Route("adressesPreferred")]
        public async Task<List<Address>> AddressPreferred()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest()
            {
                Resource = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer",
                Method = Method.Get,

            };
            restRequest.AddHeader("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);

            if (restResponse == null) { return new List<Address>(); }
            if (restResponse.Content == null)
            {
                return new List<Address>();
            }


            string? customerResponseAux = JsonConvert.DeserializeObject(restResponse.Content).ToString();

            if (customerResponseAux == null) { return new List<Address>(); }
            Customer? customerResponse = JsonConvert.DeserializeObject<Customer>(customerResponseAux);
            if (customerResponse == null) { return new List<Address>(); }
            if (customerResponse.Addresses == null) { return new List<Address>(); }
            List<Address> addressResultAux = customerResponse.Addresses.ToList();
            List<Address> addressResult = addressResultAux.FindAll(address => address.Preffered==true).ToList();
            if (addressResult == null)
            {
                return new List<Address>();
            }
            return addressResult;
        }

        [HttpGet]
        [Route("adressesPorCodigoPostal")]
        public async Task<List<Address>> AddressPorCodigoPostal([FromHeader] string codigoPostal)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest()
            {
                Resource = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer",
                Method = Method.Get,

            };
            restRequest.AddHeader("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);

            if (restResponse == null) { return new List<Address>(); }
            if (restResponse.Content == null)
            {
                return new List<Address>();
            }


            string? customerResponseAux = JsonConvert.DeserializeObject(restResponse.Content).ToString();

            if (customerResponseAux == null) { return new List<Address>(); }
            Customer? customerResponse = JsonConvert.DeserializeObject<Customer>(customerResponseAux);
            if (customerResponse == null) { return new List<Address>(); }
            if (customerResponse.Addresses == null) { return new List<Address>(); }
            List<Address> addressResultAux = customerResponse.Addresses.ToList();
            List<Address> addressResult = addressResultAux.FindAll(address => address.PostalCode == codigoPostal).ToList();
            if (addressResult == null)
            {
                return new List<Address>();
            }
            return addressResult;
        }

    }
}
