using SchoolManagementSystem.Entities.Concretes;
using SchoolManagementSystem.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Concretes
{
    public class StudentService : IStudentService
    {
        private List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 111, StudentName = "Ali", Number = 111,
                Class = new Class {Id = 1, ClassName = "a sinifi"}
            },
            new Student
            {
                Id = 112, StudentName = "Veli", Number = 112,
                Class = new Class {Id = 1, ClassName = "a sinifi"}
            },
            new Student
            {
                Id = 211, StudentName = "Yalcin", Number = 211,
                Class = new Class {Id = 2, ClassName = "b sinifi"}
            },
            new Student
            {
                Id = 212, StudentName = "Yasin", Number = 212,
                Class = new Class {Id = 2, ClassName = "b sinifi"}
            },
        };
        bool deger = true;
        public void GetById(int number)
        {
            Student studentFind = students.Find(p => p.Number == number);
            if (studentFind != null) { Console.WriteLine(studentFind.ToString());}
            else
            {
                Console.WriteLine("Bu numaraya ait ogrenci bulunmamakta");
            }
        }

        public IEnumerable<Student> GetAll()
        {
            if (students.Count > 0) { return students; }
            else { return null; }
        }

        public void Add(Student student)
        {
            foreach (var entity in students)
            {
                if (entity.Number.Equals(student.Number))
                {
                    Console.WriteLine($" Girilen '{student.Number}' Numara Sistemde Bulunmakta \n Bilgileri Kontrol Edip Tekrar Giriniz");
                    deger = false;
                }
            }
            if (deger == true)
            {
                students.Add(student);
                Console.WriteLine("Ekleme Islemi Basarili");
            }
        }

        public void Update(Student student, int number = 0, string name = "")
        {
            Student studentToUpdate = students.Find(p => p.Number == number);
            if (studentToUpdate != null) 
            { 
                studentToUpdate.Number = student.Number;
                studentToUpdate.StudentName = student.StudentName; 
                studentToUpdate.Class.ClassName = student.Class.ClassName;
                Console.WriteLine("Guncelleme Islemi Basarili"); 
            }
            else
            {
                Console.WriteLine($"'{number}' Numarasina Ait Bir Ogrenci Sistemde Bulunmadigindan Guncelleme Yapilamiyor " +
                                  $"\n Bilgileri kontrol edip tekrar deneyiniz");
            }
        }

        public void Delete(Student student)
        {
            Student studentToRemove = students.Find(p => p.Number == student.Number);
            if (studentToRemove != null) { students.Remove(studentToRemove); Console.WriteLine("Silme Islemi Basarili"); }
            else { Console.WriteLine($"'{student.Number}' Numarasina Ait Ogrenci Bulunmamakta \n Bilgileri kontrol edip tekrar deneyiniz"); }
        }
    }
}
