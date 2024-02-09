using System.ComponentModel.DataAnnotations;
/*Copyright (c) 2024 Nguyen Duong The Vi*/
namespace Nguyen_Duong_The_Vi.Models
{
    public class Category
    {
        [Key]
        public int IDCATEGORY { get; set; }

        
        public string? TITLE { get; set; } 
        public string? CONTEXT { get; set; }

        public virtual ICollection<PostCategory>? PostCategories { get; set; }
    }
}
