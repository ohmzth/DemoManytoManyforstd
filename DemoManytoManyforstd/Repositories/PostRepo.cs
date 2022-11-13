using DemoManytoManyforstd.Data;
using DemoManytoManyforstd.Interfaces;
using DemoManytoManyforstd.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoManytoManyforstd.Repositories
{
    public class PostRepo : IPost
    {
        private readonly ManytoManyContext _context;
        public PostRepo(ManytoManyContext context)
        {
            _context = context;
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
        }

        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetById(string Id)
        {
            return _context.Posts.Include("PostTags.Tag").FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }
    }
}
