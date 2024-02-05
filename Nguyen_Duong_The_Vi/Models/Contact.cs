using System.ComponentModel.DataAnnotations;

namespace Nguyen_Duong_The_Vi.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }

        public DateTime? NgayGui { get; set; }
        public string? TieuDe { get; set; }

        public string? Email { get; set; }
    }
}
