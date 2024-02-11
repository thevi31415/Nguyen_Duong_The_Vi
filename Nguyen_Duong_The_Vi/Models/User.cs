using System.ComponentModel.DataAnnotations;
/*Copyright (c) 2024 Nguyen Duong The Vi*/
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
        public string? Job {  get; set; }
        public string? Organization { get; set; }
        public string? Address { get; set; }
        public string? About {  get; set; }
        public string? Linkedln { get; set; }
        public string? Youtube { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public int? Point {  get; set; }
        public int? NumberOfVisits { get; set; }
        public int? NumberOfPosts { get; set; }
        public int? Status { get; set; }
        public DateTime? LastVisit { get; set; }

    }
}
