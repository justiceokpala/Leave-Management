using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_management.Contracts
{
  public interface IRepositoryBase<T> where T:class
    {
        ICollection<T> FindAll();
        T FindById(int id);
        bool create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save(); 
    }
}
