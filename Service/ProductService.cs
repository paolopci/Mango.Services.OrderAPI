using Mango.Services.OrderAPI.Models.Dto;
using Mango.Services.OrderAPI.Service.IService;
using Newtonsoft.Json;


namespace Mango.Services.OrderAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            // devo ritornare tutti i prodotti dal servizio ProductAPI
            // quindi creo un client come settato nella Program.cs baseAddress
            // faccio la chiamata GetAsync e ottengo un result serializzato
            // che devo poi deserializzare.
            var client = _httpClientFactory.CreateClient("Product");// baseAddress definita in Program.cs
            var response = await client.GetAsync($"/api/product");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Result));
            }

            return new List<ProductDto>();
        }
    }
}
