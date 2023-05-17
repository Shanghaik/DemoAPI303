using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestApiByWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btn_Calculate_Click(object sender, EventArgs e)
        {
            
            double weight = Convert.ToDouble(tbt_Weight.Text);
            double height = Convert.ToDouble(tbt_Height.Text);
            string apiUrl = $"https://localhost:7087/WeatherForecast/Tinh-bmi?weight={weight}&height={height}";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);
            // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Đọc từ string Json vừa thu được sang List<T>
            double bmi = JsonConvert.DeserializeObject<double>(apiData);
            btn_Result.Text = bmi.ToString();
        }
    }
}