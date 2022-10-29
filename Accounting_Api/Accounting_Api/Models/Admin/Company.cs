using System.ComponentModel.DataAnnotations;

namespace Accounting_Api.Models.Admin
{
    public class Company
    {
        [Key]
        public int ComId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        public string ComType { get; set; } = string.Empty;
        [MaxLength(100)]
        public string BusinessType { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [MaxLength(12)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        public int WorkingHour { get; set; }
    }
}
