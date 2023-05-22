using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppViews.Controllers
{
    public class SanphamController : Controller
    {
        public SanphamController()
        {

        }
        public async Task<IActionResult> GetAllSanpham()
        {
            string apiUrl = "https://localhost:7227/api/Sanpham";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra
                                                             // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API
            // Đọc từ string Json vừa thu được sang List<T>
            var sanphams = JsonConvert.DeserializeObject<List<SanPham>>(apiData);
            return View(sanphams);
        }
    }
}
