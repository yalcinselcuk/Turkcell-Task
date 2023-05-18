# HighSchoolSQL <br/>

Varlıklar : Öğrenci, Öğretmen, Ders, Bölüm <br/>

İlişkiler <br/>
---------- <br/>
Öğrenci - Ders ==> Many to Many <br/>
Öğrenci - Hoca ==> Many to Many <br/>
Ders - Bölüm ==> Many to Many <br/>
Bölüm - Öğrenci ==> One to Many <br/><br/>

![highschool](https://github.com/yalcinselcuk/HighSchoolSQL/assets/81808916/4e609691-40c3-402e-9d70-484e5262b391) <br/><br/>

create table departments( <br/>
id int not null, <br/>
departmenname varchar(50) not null, <br/>
departmennumber int, <br/>
primary key(id) <br/>
); <br/><br/>

create table Students( <br/>
id int not null,  <br/>
firstname varchar(30) not null,  <br/>
lastname varchar(30) not null,  <br/>
schoolnumber int,  <br/>
departmenid int foreign key references departments(id),  <br/>
primary key(id) <br/>
);  <br/><br/>


create table lessons( <br/>
id int not null, <br/>
lessonname varchar(50) not null, <br/>
primary key (id) <br/>
); <br/><br/>

create table teachers( <br/>
id int not null, <br/>
teachername varchar(30) not null, <br/>
teachersurname varchar(30) not null, <br/>
lessonid int foreign key references lessons(id), <br/>
departmenid int foreign key references departments(id), <br/>
primary key(id) <br/>
); <br/><br/>

create table studentsLessons( <br/>
id int not null, <br/>
studentid int foreign key references students(id), <br/>
lessonid int foreign key references lessons(id), <br/>
primary key(id) <br/>
); <br/><br/>

create table studentsTeachers( <br/>
id int not null, <br/>
studentid int foreign key references students(id), <br/>
teacherid int foreign key references teachers(id), <br/>
primary key(id) <br/>
); <br/><br/>

create table departmentsLessons( <br/>
id int not null, <br/>
departmentid int foreign key references departments(id), <br/>
lessonid int foreign key references lessons(id), <br/>
primary key(id) <br/>
); <br/>
