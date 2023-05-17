// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

Console.OutputEncoding= System.Text.Encoding.UTF8;  
Console.WriteLine("Nhập cân nặng");
double weight = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Nhập chiều cao");
double height = Convert.ToDouble(Console.ReadLine());
// Tạo chuỗi Json kết quả khi nhập tham số cho API
string apiUrl =
    $"https://localhost:7087/TinhToan/Tinh-bmi?weight={weight}&height={height}";
var httpClient = new HttpClient(); // tạo ra để callApi
var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra
                                                 // Lấy dữ liệu Json trả về từ Api được call dạng string
string apiData = await response.Content.ReadAsStringAsync();
// Lấy kqua trả về từ API
// Đọc từ string Json vừa thu được sang List<T>
double bmi = JsonConvert.DeserializeObject<double>(apiData);
Console.WriteLine("Chỉ số BMI của anh nhà là: " + bmi);
Console.ReadKey();