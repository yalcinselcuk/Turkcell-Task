using SchoolManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SchoolManagementSystem.Entities.Concretes
{
    public class Class : PersonInformation, IEntity
    {
        public string ClassName { get; set; }

        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

    }
}
