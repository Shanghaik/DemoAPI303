using System.ComponentModel.DataAnnotations;

namespace AppViews.Models
{
    public class TestValidateModel
    {
        public Guid Id { get; set; }
        [StringLength(20, ErrorMessage = 
            "Name should be less than 20 characters.")]
        public string Name { get; set; }
        [Required] // Phải có
        public string Description { get; set; }
        [Range(15, 65, ErrorMessage = "Input age is too young or old enough" +
            "to work for the company")]
        public int Age { get; set; }
        [Range(10000000, 100000000, ErrorMessage = "You are Power illusion")]
        public long ExpectSalary { get; set; }
        [EmailAddress]
        public String Email { get; set; }
        /*
         * Ta có thể thực hiện được validate trực tiếp
         * trên model được tạo ra với Validation attributes
         * Validation Atributes có thể hỗ trợ kiểm tra với
         * hầu hết các kiểu dữ liệu nguyên thủy và string
         * Khi xử lý chúng ta sử dụng phương thức 
         * ModelState.IsValid() để xác thực và có thể đưa 
         * ra các kết quả...
         */
    }
}
