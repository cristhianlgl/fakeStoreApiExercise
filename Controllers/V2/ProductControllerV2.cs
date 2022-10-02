using fakeStoreApiExercise.DTOs.V2;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace fakeStoreApiExercise.Controllers.V2
{
    [ApiVersion("2.0")]
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

        [MapToApiVersion("2.0")]
        [HttpGet(Name ="GetData")]
        public async Task<IActionResult> GetDataAsync()
        {
            var response = await _httpClient.GetStreamAsync(_UrlApi);
            var data = await JsonSerializer.DeserializeAsync<List<Product>>(response);
            return Ok(data);
        }
    }
}
