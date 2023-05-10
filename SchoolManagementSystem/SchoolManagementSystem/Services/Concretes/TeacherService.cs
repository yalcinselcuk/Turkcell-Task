using SchoolManagementSystem.Entities.Concretes;
using SchoolManagementSystem.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Concretes
{
    public class TeacherService : ITeacherService
    {
        public List<Teacher> teachers = new List<Teacher>
        {
            new Teacher {Id = 11,TeacherNo = 11, TeacherName = "Ahmet Hoca", Class = new Class{ClassName = "a sinifi"}},
            new Teacher {Id = 21, TeacherNo = 21, TeacherName = "Mehmet Hoca", Class = new Class{ClassName = "b sinifi"}},
        };
        bool deger = true;
        public void GetById(int id)
        {
            Teacher teacherFind = teachers.Find(p => p.Id == id);
            if (teacherFind != null) { Console.WriteLine(teacherFind.ToString()); }
            else
            {
                Console.WriteLine("Bu numaraya ait ogretmen bulunmamakta");
            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            if (teachers.Count > 0) { return teachers; }
            else { return null; };
        }

        public void Add(Teacher teacher)
        {
            foreach (var entity in teachers)
            {
                if (entity.TeacherNo.Equals(teacher.TeacherNo))
                {
                    Console.WriteLine($" Girilen '{teacher.TeacherNo}' Numara Sistemde Bulunmakta \n Bilgileri Kontrol Edip Tekrar Giriniz");
                    deger = false;
                }
            }
            if (deger == true)
            {
                teachers.Add(teacher);
                Console.WriteLine("Ekleme Islemi Basarili");
            }
        }
        public void Update(Teacher teacher, int number = 0, string name = "")
        {
            Teacher teacherToUpdate = teachers.Find(p => p.TeacherNo == number);
            if (teacherToUpdate != null)
            {
                teacherToUpdate.TeacherNo = teacher.TeacherNo;
                teacherToUpdate.TeacherName = teacher.TeacherName;
                teacherToUpdate.Class.ClassName = teacher.Class.ClassName;
                Console.WriteLine("Guncelleme Islemi Basarili");
            }
            else
            {
                Console.WriteLine($"'{number}' Numarasina Ait Bir Ogretmen Sistemde Bulunmadigindan Guncelleme Yapilamiyor " +
                                  $"\n Bilgileri kontrol edip tekrar deneyiniz");
            }
        }

        public void Delete(Teacher teacher)
        {
            Teacher teacherToRemove = teachers.Find(p => p.TeacherNo == teacher.TeacherNo);
            if (teacherToRemove != null) { teachers.Remove(teacherToRemove); Console.WriteLine("Silme Islemi Basarili"); }
            else { Console.WriteLine($"'{teacher.TeacherNo}' Numarasina Ait Ogretmen Bulunmamakta \n Bilgileri kontrol edip tekrar deneyiniz"); }
        }
        
    }
}
