using fakeStoreApiExercise.DTOs.V1;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace fakeStoreApiExercise.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private const string _UrlApi = "https://fakestoreapi.com/products";
        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("1.0")]
        [HttpGet(Name ="GetData")]
        public async Task<IActionResult> GetDataAsync()
        {
            var response = await _httpClient.GetStreamAsync(_UrlApi);
            var data = await JsonSerializer.DeserializeAsync<List<Product>>(response);
            return Ok(data);
        }
    }
}
