using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TestAPIMVC.Models;

namespace TestAPIMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PrivacyAsync()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PrivacyAsync(double weight, double height)
        {
            string apiUrl =
    $"https://localhost:7087/TinhToan/Tinh-bmi?weight={weight}&height={height}";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra
                                                             // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API
            // Đọc từ string Json vừa thu được sang List<T>
            string bmi = JsonConvert.DeserializeObject<string>(apiData);
            ViewData["result"] = $"Với cân nặng {weight} và chiều cao {height}" +
                $" thì chỉ số BMI của bé là: {bmi}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}