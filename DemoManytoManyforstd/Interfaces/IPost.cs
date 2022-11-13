using DemoManytoManyforstd.Models;

namespace DemoManytoManyforstd.Interfaces
{
    public interface IPost
    {
        List<Post> GetAll();
        Post GetById(String Id);
        void Insert(Post post);
        void Update(Post post);
        void Delete(Post post);

    }
}
