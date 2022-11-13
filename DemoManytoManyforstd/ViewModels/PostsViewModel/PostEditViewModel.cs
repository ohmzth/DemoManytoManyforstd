using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoManytoManyforstd.ViewModels.PostsViewModel
{
    public class PostEditViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public List<SelectListItem> Tags { get; set; }

        public string[] SelecttedTags { get; set; }
    }
}
