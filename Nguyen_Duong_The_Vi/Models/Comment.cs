using System.ComponentModel.DataAnnotations;
/*Copyright (c) 2024 Nguyen Duong The Vi*/
namespace Nguyen_Duong_The_Vi.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public int? IDBAIVIET { get; set; }
        public int? IDUSER { get; set; }
        public int? XACMINH { get; set; }
        public string? Role { get; set; }
        public int? LIKE { get; set; }
        public string? TENUSER { get; set; }
        public string? COMMENT { get; set; }
        public DateTime? NGAYBINHLUAN { get; set; }

    }
}
