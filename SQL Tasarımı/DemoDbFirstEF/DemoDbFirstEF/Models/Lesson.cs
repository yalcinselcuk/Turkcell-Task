using System;
using System.Collections.Generic;

namespace DemoDbFirstEF.Models;

public partial class Lesson : IEntity
{
    public int Id { get; set; }

    public string Lessonname { get; set; } = null!;

    public virtual ICollection<DepartmentsLesson> DepartmentsLessons { get; set; } = new List<DepartmentsLesson>();

    public virtual ICollection<StudentsLesson> StudentsLessons { get; set; } = new List<StudentsLesson>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
