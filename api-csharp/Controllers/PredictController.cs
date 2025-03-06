using api_csharp.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Text;

namespace api_csharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PredictController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        public PredictController(ILogger<PredictController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        [HttpPost("{*inputValue}")]
        public async Task<IActionResult> Predict([FromRoute] string inputValue)
        {
            if (string.IsNullOrWhiteSpace(inputValue))
            {
                _logger.LogWarning("Nenhum número foi fornecido na URL.");
                return BadRequest("Nenhum número foi fornecido.");
            }

            var numberList = inputValue.Split("/");
            var listOfNumbers = numberList.Select(x => Convert.ToDouble(x)).ToList();

            var json = new
            {
                numbers = listOfNumbers
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(json), Encoding.UTF8, "application/json");
            var pythonApiUrl = "http://127.0.0.1:8000/predict/";
            var response = await _httpClient.PostAsync(pythonApiUrl, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var pythonResponse = await response.Content.ReadAsStringAsync();
                return Ok(pythonResponse);
            }
            else
            {
                return BadRequest("Erro na requisição para a API Python");
            }
        }
    }
}
