using System.ComponentModel.DataAnnotations;

namespace ThemeApplyPractice.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
