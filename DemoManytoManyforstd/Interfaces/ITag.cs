using DemoManytoManyforstd.Models;

namespace DemoManytoManyforstd.Interfaces
{
    public interface ITag
    {
        List<Tag> GetAll();
        Tag GetById(string Id);
        void Insert(Tag tag);
        void Update(Tag tag);
        void Delete(Tag tag);
    }
}
