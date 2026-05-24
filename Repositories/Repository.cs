using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
                throw new Exception("Database connection error", ex);
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
                throw new Exception("Failed to retrieve record from database.", ex);
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
                throw new Exception("Error while saving data.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("Unable to establish a connection to the database. Make sure that SQL Server is available.", ex);
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
                throw new Exception("An error occurred while executing a database query.", ex);
            }
        }
    }
}
