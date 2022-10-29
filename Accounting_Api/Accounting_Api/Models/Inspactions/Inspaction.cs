using System.ComponentModel.DataAnnotations;

namespace Accounting_Api.Models.Inspactions
{
    public class Inspaction
    {
        public int InspactionId { get; set; }
        [StringLength(20)]
        public string Status { get; set; } = string.Empty;
        [StringLength(200)]
        public string Comments { get; set; } = string.Empty;
        public int InspactionTypeId { get; set; }
        public InspactionType? InspactionType { get; set; }
    }

}
