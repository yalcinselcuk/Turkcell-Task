using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IServiceRepository<T>
    {
        void GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update( T entity, int number = 0, string name = "");
        void Delete(T entity);
    }
}
