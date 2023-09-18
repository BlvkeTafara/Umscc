using aspnet_boilerplate_mvc.DataAccess;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace aspnet_boilerplate_mvc.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void BulkDelete(IEnumerable<T> entities)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.BulkDelete(entities);
                transaction.Commit();
            }
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            /*using (var transaction = _context.Database.BeginTransaction())
            {
                _context.BulkInsert(entities);
                transaction.Commit();
            }*/
            _dbSet.AddRange(entities);
        }

        public void BulkUpdate(IEnumerable<T> entities)
        {
           using (var transaction = _context.Database.BeginTransaction())
            {
                _context.BulkUpdate(entities);
                transaction.Commit();
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, List<string> includes = null)
        {

            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

            }

            return query.AsNoTracking().Where(predicate);


        }

        public IEnumerable<T> GetAll(List<string> includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.AsNoTracking().ToList();

        }

        public T GetOne(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.AsNoTracking().Where(expression).FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
