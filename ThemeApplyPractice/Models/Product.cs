using System.ComponentModel.DataAnnotations;

namespace ThemeApplyPractice.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
    }
}
