using DemoDbFirstEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDbFirstEF.Data.Repository
{
    public class EfDepartmentRepository : IDepartmentRepository
    {
        public Task Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Department>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
