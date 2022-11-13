using DemoManytoManyforstd.Data;
using DemoManytoManyforstd.Interfaces;
using DemoManytoManyforstd.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoManytoManyforstd.Repositories
{
    public class TagRepo : ITag
    {
        private readonly ManytoManyContext _context;
        public TagRepo(ManytoManyContext context)
        {
            _context = context;
        }
        public void Delete(Tag tag)
        {
            _context.Tags.Remove(tag);
        }

        public List<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }

        public Tag GetById(string Id)
        {
            return _context.Tags.FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Tag tag)
        {
            _context.Tags.Add(tag);
        }

        public void Update(Tag tag)
        {
            _context.Tags.Update(tag);
        }
    }
}
