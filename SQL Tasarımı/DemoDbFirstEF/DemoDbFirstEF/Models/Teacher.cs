using System;
using System.Collections.Generic;

namespace DemoDbFirstEF.Models;

public partial class Teacher : IEntity
{
    public int Id { get; set; }

    public string Teachername { get; set; } = null!;

    public string Teachersurname { get; set; } = null!;

    public int? Lessonid { get; set; }

    public int? Departmenid { get; set; }

    public virtual Department? Departmen { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual ICollection<StudentsTeacher> StudentsTeachers { get; set; } = new List<StudentsTeacher>();
}
