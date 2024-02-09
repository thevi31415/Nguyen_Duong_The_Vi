using System.ComponentModel.DataAnnotations;
/*Copyright (c) 2024 Nguyen Duong The Vi*/
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
