using backtpp.Interfaces;
using backtpp.Models;
using Microsoft.EntityFrameworkCore;

namespace backtpp.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly tppContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericService(tppContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public void Add(TEntity data)
        {
            _dbSet.Add(data);
            _context.SaveChanges();
        }

        public bool Delete(long id)
        {
            TEntity? dataToDelete = _dbSet.Find(id);
            if (dataToDelete is null)
            {
                return false;
            }

            _dbSet.Remove(dataToDelete);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
