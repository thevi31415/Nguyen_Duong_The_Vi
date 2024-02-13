using System.ComponentModel.DataAnnotations;

namespace Nguyen_Duong_The_Vi.Models
{
    public class PostTemp
    {
        [Key]
        public int ID { get; set; }

        public int? VIEW { get; set; }

        public int? IDTAUTHOR { get; set; }
        public int? LIKE { get; set; }
        public string? AUTHOR { get; set; }

        public string? SUMMARY { get; set; }

        public string? TITLE { get; set; }

        public DateTime PUBLISHED { get; set; }

        public string? CONTEXT { get; set; }

        public string? TEMP { get; set; }

        public int? STATUS { get; set; }    
        public virtual ICollection<PostCategory>? PostCategories { get; set; }
    }
}
