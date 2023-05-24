using System;
using System.Collections.Generic;

namespace DemoDbFirstEF.Models;

public partial class Student : IEntity
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int? Schoolnumber { get; set; }

    public int? Departmenid { get; set; }

    public virtual Department? Departmen { get; set; }

    public virtual ICollection<StudentsLesson> StudentsLessons { get; set; } = new List<StudentsLesson>();

    public virtual ICollection<StudentsTeacher> StudentsTeachers { get; set; } = new List<StudentsTeacher>();
}
