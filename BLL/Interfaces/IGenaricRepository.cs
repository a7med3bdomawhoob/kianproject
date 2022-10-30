using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenaricRepository<T>
    {
        Task Add( T Entity );
        T Delete(T Entity);
        Task SaveChanges();
        T Update(T Entity);
        Task<IReadOnlyList<T>> getallemployees();
        public Task<T> search(int ? id);
    }
}
