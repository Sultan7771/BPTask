

using StationAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace StationAPI.Services
{
    public class StationServices<T> : IStationServices<T> where T : class
    {
        private readonly DataAccessContext _context;

        public StationServices()
        {
        }

        public StationServices(DataAccessContext context)
        {
            _context = context;
        }

        public void AddRow(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteRow(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAllRows()
        {
            return _context.Set<T>().ToList();
        }

        public T GetRowById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public bool UpdateRow(int id, T entity)
        {
            var oldVal = _context.Set<T>().Find(id);
            if (oldVal != null)
            {
                _context.Entry(oldVal).State = EntityState.Detached;
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
