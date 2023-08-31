using System.ComponentModel.DataAnnotations;

namespace ThemeApplyPractice.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }
        public string VendorName { get; set; }
    }
}
