using System;
using System.ComponentModel.DataAnnotations;

namespace ThemeApplyPractice.Models
{
    public class Issuance
    {
        [Key]
        public int Issuance_Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string Employee { get; set; }
        public string Product { get; set; }
        public int Qty { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
    }
}
