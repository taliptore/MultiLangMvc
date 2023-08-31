using Microsoft.EntityFrameworkCore;
using MultiLangMvc.Models;
using static MultiLangMvc.Repo.IGenericRepository;
using System.Linq.Expressions;

namespace MultiLangMvc.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
       

        public GenericRepository(AppDbContext context)
        {
            _context = context;
           
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();

        }

        public async Task AddRangeAsycn(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            /*AsNoTracking yazma amacı veriye çek ama ram alma ram alırsa sürekli takip ettiği için performans düşüklüğü oluyor. */
            return _context.Set<T>().ToList().AsQueryable();
        }

        public IQueryable<T> GetAllIncluding(
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                {

                    queryable = queryable.Include(includeProperty);
                }
            }

            /*AsNoTracking yazma amacı veriye çek ama ram alma ram alırsa sürekli takip ettiği için performans düşüklüğü oluyor. */
            return queryable.AsNoTracking().AsQueryable();
        }




        public async Task<T> GetByIdAscy(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public void Romeve(T entity)
        {
            _context.Remove(entity);
        }

        public void RomeveRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

    }
}
