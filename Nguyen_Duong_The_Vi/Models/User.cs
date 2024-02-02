using System.ComponentModel.DataAnnotations;

namespace Nguyen_Duong_The_Vi.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string? Code { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public int? NumberOfVisits { get; set; }
        public int? NumberOfPosts { get; set; }
        public int? Status { get; set; }
        public DateTime? LastVisit { get; set; }

    }
}
