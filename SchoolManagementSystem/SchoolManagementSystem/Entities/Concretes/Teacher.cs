using SchoolManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Entities.Concretes
{
    public class Teacher : PersonInformation, IEntity
    {

        public int TeacherNo{ get; set; }
        public string TeacherName { get; set; }
        public Class @Class { get; set; }

        public override string ToString()
        {
            return $"\n Teacher Id : {Id},\n Teacher No : {TeacherNo},\nTeacher Name : {TeacherName},\n Sinifi : {Class.ClassName}";
        }
    }
}
