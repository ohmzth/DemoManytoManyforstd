using DemoManytoManyforstd.Models;

namespace DemoManytoManyforstd.ViewModels.PostsViewModel
{
    public class PostViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public List<PostTag> PostTags { get; set; } = new List<PostTag>();

    }
}
