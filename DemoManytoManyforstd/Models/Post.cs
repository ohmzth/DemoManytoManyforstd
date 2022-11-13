using System.ComponentModel.DataAnnotations.Schema;

namespace DemoManytoManyforstd.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Title { get; set; }
          
        public string Description { get; set; }
        public List<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}
