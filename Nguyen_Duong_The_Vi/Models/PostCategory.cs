using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nguyen_Duong_The_Vi.Models
{
    public class PostCategory
    {
        [Key]
        public int ID { get; set; }

  
        [ForeignKey("Post")]
        public int IDPOST { get; set; }


        [ForeignKey("Category")]
        public int IDCATEGORY { get; set; }

        public virtual Post? Post { get; set; }

        public virtual Category? Category { get; set; }
    }
}
