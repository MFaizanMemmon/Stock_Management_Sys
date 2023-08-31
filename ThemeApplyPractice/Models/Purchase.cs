using System;
using System.ComponentModel.DataAnnotations;

namespace ThemeApplyPractice.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public DateTime PurDate { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        
        public int Price { get; set; }
        public string Vendor { get; set; }
        public int VendorId { get; set; }
        public int ProductId { get; set; }

    }
}
