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
        // Bất đồng bộ async-await là một khái niệm trong lập trình web 
        // Có nhiều cách để xử lý bất đồng bộ tuy nhiên quá trình này sẽ thường
        // được diễn ra như sau:
        /*
         * Giả xử khi người dùng tạo 1 request, request đó gọi là một luồng chính
         * luồng chính này có thể chứa nhiều luồng nhỏ để sinh ra response cuối cùng
         * khi đó việc xử lý các luồng con này có thể được chia nhỏ ra để gia tăng
         * hiệu suất và luồng chính sẽ bị delay đến khi nào các luông kia được thực
         * thi hoàn toàn. Ví dụ
         * Khi thanh toán 1 hóa đơn hoàn tất thì sẽ có các tác vụ nào
         * > Tạo 1 hóa đơn trong db
         * > Trừ số lượng các SP trong db
         * > Xóa dữ liệu trong giỏ hàng
         * > Thêm hóa đơn vào lịch sử mua hàng
         * ... 
         * Khi đó các tác vụ này có thể được chạy độc lập cho đến khi tất cả hoàn thành
         * => Xong luồng thanh toán
         * Trong cơ chế sử dụng thread pool, thì mỗi thread sẽ không bao giờ rảnh nếu
         * số lượng tác vụ đang hoạt động > số thread
         * VD chip có 20 luồng thì nếu số lượng tác vụ > 20 thì các luồng này sẽ luận 
         * phiên hoạt động cho đến khi hoàn tất tất cả  
         */
    }
}
