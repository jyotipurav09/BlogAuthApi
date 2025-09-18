

using BlogAuthApi.Data.Data;
using BlogAuthApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogAuthApi.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DataContext _context;

        public BlogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs.Include(b => b.Employee).ToListAsync();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blogs.Include(b => b.Employee)
                                       .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Blog> AddAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<Blog?> UpdateAsync(Blog blog)
        {
            var existing = await _context.Blogs.FindAsync(blog.Id);
            if (existing == null) return null;

            existing.Title = blog.Title;
            existing.Description = blog.Description;
            existing.IsPublished = blog.IsPublished;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return false;

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    }
