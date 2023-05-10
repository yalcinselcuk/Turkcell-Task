using SchoolManagementSystem.Entities.Concretes;
using SchoolManagementSystem.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Concretes
{
    public class ClassService : IClassService
    {
        private List<Class> _classes = new List<Class>
        {
            new Class { Id = 1, ClassName = "a sinifi",
                        Teacher = new Teacher{Id = 11, TeacherName = "Ahmet Hoca" , TeacherNo = 11},
                        Students = new List<Student>
                        {
                            new Student{Id = 111, StudentName = "Ali", Number = 111},
                            new Student{Id = 112, StudentName = "Veli", Number = 112},
                        }
            },
            new Class { Id = 2, ClassName = "b sinifi" ,
                        Teacher = new Teacher{Id = 21, TeacherName = "Mehmet Hoca", TeacherNo = 21 },
                        Students = new List<Student>
                        {
                            new Student{Id = 211, StudentName = "Yalcin", Number = 211},
                            new Student{Id = 212, StudentName = "Yasin", Number = 212},
                        } },
        };
        bool deger = true;
        public void GetById(int id)
        {
        }
        public IEnumerable<Class> GetAll()
        {
            if (_classes.Count > 0) { return _classes; }
            else { return null; }
        }

        public void Add(Class @class)
        {
            foreach (var entity in _classes)
            {
                if (entity.ClassName.Equals(@class.ClassName))
                {
                    Console.WriteLine($"'{@class.ClassName}' sistemde bulunmakta \n Baska bir class giriniz");
                    deger = false;
                }
            }

            if (deger == true)
            {
                _classes.Add(@class);
                Console.WriteLine("Ekleme Islemi Basarili");

                if (@class.Teacher == (null))
                {
                    randomTeacherAdd();

                }
            }
        }

        public void Update(Class @class, int number = 0, string name = "")
        {
            Class classToUpdate = _classes.Find(p => p.ClassName == name);
            if (classToUpdate != null) { classToUpdate.ClassName = @class.ClassName; Console.WriteLine("Guncelleme Islemi Basarili"); }
            else
            {
                Console.WriteLine($"'{name}' adinda bir sinif sistemde bulunmadigindan guncelleme yapilamiyor " +
                                  $"\n Bilgileri kontrol edip tekrar deneyiniz");
            }

        }

        public void Delete(Class @class)
        {

            Class classToRemove = _classes.Find(p => p.ClassName == @class.ClassName);
            if (classToRemove != null) { _classes.Remove(classToRemove); Console.WriteLine("Silme Islemi Basarili"); }
            else { Console.WriteLine($"'{@class.ClassName}' adına ait class bulunmamakta \n Bilgileri kontrol edip tekrar deneyiniz"); }

        }
        public void randomTeacherAdd()
        {
            Random random = new Random();
            int randomIndexClass = random.Next(_classes.Count);
            _classes[_classes.Count - 1].Teacher = _classes[randomIndexClass].Teacher;

        }
    }
}
