using System.Linq.Expressions;

namespace MultiLangMvc.Repo
{
    public interface IGenericRepository
    {
        public interface IGenericRepository<T> where T : class
        {
            IQueryable<T> GetAll();
            Task<T> GetByIdAscy(int id);
            IQueryable<T> Where(Expression<Func<T, bool>> expression);
            Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
            /// <summary>
            /// ilişkili tablo ile beraber verileri çağırma işlemi için yapılıdı
            /// </summary>
            /// <param name="GetAllIncluding">ilişkili properti alınacaksa</param>
            /// <returns></returns>
            IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
            Task AddAsync(T entity);
            Task AddRangeAsycn(IEnumerable<T> entities);
            void Update(T entity); // update ve remove asyc olması yok EFCORE
            void Romeve(T entity);
            void RomeveRange(IEnumerable<T> entities);
        }
    }
}
