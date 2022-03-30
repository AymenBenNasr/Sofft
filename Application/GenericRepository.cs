using Infrastructure.Data;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context; 
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
