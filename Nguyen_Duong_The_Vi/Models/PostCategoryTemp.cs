using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nguyen_Duong_The_Vi.Models
{
    public class PostCategoryTemp
    {
        [Key]
        public int ID { get; set; }


     
        public int IDPOSTTEMP { get; set; }


     
        public int IDCATEGORY { get; set; }

       
    }
}
