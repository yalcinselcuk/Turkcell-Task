using SchoolManagementSystem.Entities.Concretes;
using SchoolManagementSystem.Services.Abstracts;
using SchoolManagementSystem.Services.Concretes;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

IServiceRepository<Class> classService = new ClassService();
IServiceRepository<Student> studentService = new StudentService();
IServiceRepository<Teacher> teacherService = new TeacherService();
Class @class;
Teacher teacher;
Student student;
string infNumber;
int informationNumber;
string informationName;
string informationClass;

Console.WriteLine("Okul Yonetim Sistemine Hosgeldiniz");

bool deger = true;
while (deger)
{
    SchoolMenu();
    Console.Write("Isleminizi Seciniz : ");

    int islem = Convert.ToInt32(Console.ReadLine());

    switch (islem)
    {
        case 1:

            if (classService.GetAll() != null)
            {
                ClassToString();
            }
            else { Console.WriteLine("sisteme hicbir sinif girilmemis !!!"); }
            break;

        case 2:
            Console.Write("Eklenecek Sınıfı Giriniz : ");
            string className = Console.ReadLine();
            @class = new Class { ClassName = className };

            classService.Add(@class);
            break;

        case 3:
            if (classService.GetAll() != null)
            {
                Console.WriteLine("Sınıf Adlari");
                foreach (var liste in classService.GetAll())
                {
                    Console.WriteLine($"{liste.ClassName}");
                }
                Console.Write("Silinecek Sinifi Giriniz : ");
                string deleteClassName = Console.ReadLine();
                @class = new Class { ClassName = deleteClassName };
                classService.Delete(@class);
            }
            else { Console.WriteLine("sistemde silinecek sinif bulunmamakta!!!"); }
            break;
        case 4:
            if (classService.GetAll() != null)
            {
                Console.WriteLine("Sınıf Adlari");
                foreach (var liste in classService.GetAll())
                {
                    Console.WriteLine($"{liste.ClassName}");
                }
                Console.Write("Guncellenecek Sinifin Adi : ");
                string defaultClassName = Console.ReadLine();
                Console.Write("Yeni Sinif Adini Giriniz : ");
                string updateClassName = Console.ReadLine();
                @class = new Class { ClassName = updateClassName };
                classService.Update(@class, 0, defaultClassName);
            }
            else { Console.WriteLine("sistemde guncellenecek sinif bulunmamakta!!!"); }
            break;
        case 5:
            Console.Write("Ogrenci No : ");
            int number = Convert.ToInt32(Console.ReadLine());
            studentService.GetById(number);
            break;
        case 6:
            if (studentService.GetAll != null)
            {
                StudentToString();
            }
            else { Console.WriteLine("sistemde ogrenci bulunmamakta !!!"); }
            break;
        case 7:
            Console.Write(" Ogrencinin No : ");
            informationNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Ogrencinin Adi : ");
            informationName = Console.ReadLine();
            Console.Write("Ogrencinin Sinifi : ");
            informationClass = Console.ReadLine();
            student = new Student { Id = informationNumber, Number = informationNumber, StudentName = informationName, Class = new Class { ClassName = informationClass } };

            studentService.Add(student);
            break;
        case 8:
            if (studentService.GetAll() != null)
            {
                StudentToString();

                Console.Write("Sistemde bulunacak ogrencinin no :");
                int search = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Ogrencinin No : ");
                informationNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Ogrencinin Adi : ");
                informationName = Console.ReadLine();
                Console.Write("Ogrencinin Sinifi : ");
                informationClass = Console.ReadLine();
                student = new Student { Id = informationNumber, Number = informationNumber, StudentName = informationName, Class = new Class { ClassName = informationClass } };
                studentService.Update(student, search, "");

            }
            else { Console.WriteLine("sistemde guncellenecek ogrenci bulunmamakta!!!"); }
            break;
        case 9:
            if (studentService.GetAll() != null)
            {
                StudentToString();

                Console.Write("Silinecek Ogrencinin No : ");
                informationNumber = Convert.ToInt32(Console.ReadLine());
                student = new Student { Number = informationNumber };
                studentService.Delete(student);
            }
            else { Console.WriteLine("sistemde silinecek ogrenci bulunmamakta!!!"); }
            break;
        case 10:
            Console.Write("Ogretmen No : ");
            int teacherNumber = Convert.ToInt32(Console.ReadLine());
            teacherService.GetById(teacherNumber);
            break;
        case 11:
            if (teacherService.GetAll != null)
            {
                TeacherToString();
            }
            else { Console.WriteLine("sistemde Ogretmen bulunmamakta !!!"); }
            break;
        case 12:
            Console.Write(" Ogretmen No : ");
            infNumber = Console.ReadLine();
            if (int.TryParse(infNumber, out informationNumber))
            {
            }
            else
            {
                Console.WriteLine("Numara yerine yazi girdiniz !!!");
                break;
            }
            Console.Write(" Ogretmen Adi : ");
            informationName = Console.ReadLine();
            Console.Write("Ogretmen Sinifi : ");
            informationClass = Console.ReadLine();
            teacher = new Teacher { Id = informationNumber, TeacherNo = informationNumber, TeacherName = informationName, Class = new Class { ClassName = informationClass } };

            teacherService.Add(teacher);
            break;
        case 13:
            if (teacherService.GetAll() != null)
            {
                TeacherToString();

                Console.Write("Sistemden guncellenecek ogretmenin no :");
                int search = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Ogretmenin No : ");
                informationNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Ogretmenin Adi : ");
                informationName = Console.ReadLine();
                Console.Write("Ogretmenin Sinifi : ");
                informationClass = Console.ReadLine();
                teacher = new Teacher { Id = informationNumber, TeacherNo = informationNumber, TeacherName = informationName, Class = new Class { ClassName = informationClass } };
                teacherService.Update(teacher, search, "");

            }
            else { Console.WriteLine("sistemde guncellenecek ogretmen bulunmamakta!!!"); }
            break;
        case 14:
            if (teacherService.GetAll() != null)
            {

                TeacherToString();

                Console.Write("Silinecek Ogretmenin No : ");
                informationNumber = Convert.ToInt32(Console.ReadLine());
                teacher = new Teacher { TeacherNo = informationNumber };
                teacherService.Delete(teacher);
            }
            else { Console.WriteLine("sistemde silinecek ogretmen bulunmamakta!!!"); }
            break;
        case 0:
            Console.WriteLine("Sistemden Cikis Yapildi");
            deger = false;
            break;
    }


}
void SchoolMenu()
{
    Console.WriteLine();
    Console.WriteLine("1.Sınıfları Listele");
    Console.WriteLine("2.Sınıf Ekle");
    Console.WriteLine("3.Sinif Sil");
    Console.WriteLine("4.Sinif Guncelle");
    Console.WriteLine("5.Ogrenci Bul");
    Console.WriteLine("6.Ogrencileri Listele");
    Console.WriteLine("7.Ogrenci Ekle");
    Console.WriteLine("8.Ogrenci Guncelle");
    Console.WriteLine("9.Ogrenci Sil");
    Console.WriteLine("10.Ogretmen Bul");
    Console.WriteLine("11.Ogretmen Listele");
    Console.WriteLine("12.Ogretmen Ekle");
    Console.WriteLine("13.Ogretmen Guncelle");
    Console.WriteLine("14.Ogretmen Sil");
    Console.WriteLine("0. Cikis");
    Console.WriteLine();
}
void ClassToString()
{
    Console.WriteLine();
    Console.WriteLine("Sınıf Adlari");
    Console.WriteLine();
    foreach (var classInformation in classService.GetAll())
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($" Sinif Id : {classInformation.Id}");
        Console.WriteLine($" Sinif Adi : {classInformation.ClassName}");
        Console.WriteLine($" Sinif Ogretmeninin Id : {classInformation.Teacher.Id}");
        Console.WriteLine($" Sinif Ogretmeninin Adi : {classInformation.Teacher.TeacherName}");
        Console.WriteLine("------------------------------------");
        Console.WriteLine();
        Console.WriteLine($"{classInformation.ClassName} Ogrencileri");
        Console.WriteLine();
        if (classInformation.Students != null)
        {

            foreach (var studentInformation in classInformation.Students)
            {
                Console.WriteLine($"Ogrencinin Id : {studentInformation.Id}");
                Console.WriteLine($"Ogrencinin StudentName : {studentInformation.StudentName}");
                Console.WriteLine($"Ogrencinin Number : {studentInformation.Number}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("bu sinifta ogrenci bulunmamakta");
        }
    }
}
void StudentToString()
{
    Console.WriteLine();
    Console.WriteLine("Ogrenciler");
    Console.WriteLine();
    foreach (var studentInformation in studentService.GetAll())
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($" Ogrenci Id : {studentInformation.Id}");
        Console.WriteLine($" Ogrenci Adi : {studentInformation.StudentName}");
        Console.WriteLine($" Ogrenci No : {studentInformation.Number}");
        Console.WriteLine($" Ogrencinin Sinifi : {studentInformation.Class.ClassName}");
        Console.WriteLine("------------------------------------");


    }
}
void TeacherToString()
{
    Console.WriteLine();
    Console.WriteLine("Ogretmenler");
    Console.WriteLine();
    foreach (var teacherInformation in teacherService.GetAll())
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($" Ogretmen Id : {teacherInformation.Id}");
        Console.WriteLine($" Ogretmen Adi : {teacherInformation.TeacherName}");
        Console.WriteLine($" Ogretmen No : {teacherInformation.TeacherNo}");
        Console.WriteLine($" Ogretmen Sinifi : {teacherInformation.Class.ClassName}");
        Console.WriteLine("------------------------------------");


    }
}