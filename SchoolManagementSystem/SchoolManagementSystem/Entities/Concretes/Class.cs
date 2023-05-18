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

        private Teacher isNull;
        public Teacher Teacher 
        {
            get {return isNull ; }
            set { isNull = new Teacher { Id = 0} ; }
        }
        public List<Student> Students { get; set; }

    }
}
