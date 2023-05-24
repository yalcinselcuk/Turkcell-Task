using DemoDbFirstEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDbFirstEF.Data.Repository
{
    public interface IRepository<T> where T : class, IEntity, new() 
    {
        Task Add(T entity);
        Task Delete(int id);
        Task Update(T entity);
        Task<ICollection<T>> GetAll();
    }
}
