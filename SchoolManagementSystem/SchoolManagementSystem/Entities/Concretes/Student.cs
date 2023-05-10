using SchoolManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Entities.Concretes
{
    public class Student : PersonInformation, IEntity
    {
        public string StudentName { get; set; }
        public int Number { get; set; }
        public Class Class { get; set; }

        public override string ToString()
        {
            return $"\n Ogrenci No : {Number},\n Ogrenci Adi : {StudentName},\n Sinifi : {Class.ClassName}" ;
        }
    }
}
