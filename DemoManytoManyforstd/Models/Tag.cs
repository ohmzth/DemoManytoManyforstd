using System.ComponentModel.DataAnnotations.Schema;

namespace DemoManytoManyforstd.Models
{
    public class Tag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Title { get; set; }

        public List<PostTag> PostTags { get; set; } 

    }
}
