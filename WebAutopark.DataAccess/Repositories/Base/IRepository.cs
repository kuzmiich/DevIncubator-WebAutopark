using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Repositories.Base
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();

        void Create(T element);
        void Update(T element);

        void Save();
        void Delete(int id);
    }
}
