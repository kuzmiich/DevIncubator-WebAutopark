using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using static System.GC;

namespace WebAutopark.DataAccess.Repositories
{
    public class VehicleRepository : IRepository<Vehicle>, IDisposable
    {
        private static bool _disposed = false;

        public Vehicle Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(Vehicle obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            SuppressFinalize(this);
        }
    }
}
