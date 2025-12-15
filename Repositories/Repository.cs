using System;
using System.Collections.Generic;
using System.Linq;
using Data.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            try
        {
            return _dbSet.ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception("Помилка з'єднання з базою даних під час читання даних.", ex);
            }
        }

        public T GetById(int id)
        {
            try
        {
            return _dbSet.Find(id);
            }
            catch (SqlException ex)
            {
                throw new Exception("Не вдалося отримати запис з бази даних. Перевірте з'єднання.", ex);
            }
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException)
            {
                throw new Exception("Помилка під час збереження даних. Перевірте з'єднання з базою даних.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("Неможливо встановити підключення до бази даних. Переконайтеся, що SQL Server доступний.", ex);
            }
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
        {
            return _dbSet.Where(predicate).ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception("Сталася помилка під час виконання запиту до бази даних.", ex);
            }
        }
    }
}
