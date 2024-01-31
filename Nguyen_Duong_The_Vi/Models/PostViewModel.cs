namespace Nguyen_Duong_The_Vi.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public List<Category> Categories { get; set; }
        public List<int> SelectedCategories { get; set; }
    }
}
