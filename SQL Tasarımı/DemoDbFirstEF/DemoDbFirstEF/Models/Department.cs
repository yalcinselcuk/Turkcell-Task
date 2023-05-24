using System;
using System.Collections.Generic;

namespace DemoDbFirstEF.Models;

public partial class Department : IEntity
{
    public int Id { get; set; }

    public string Departmenname { get; set; } = null!;

    public int? Departmennumber { get; set; }

    public virtual ICollection<DepartmentsLesson> DepartmentsLessons { get; set; } = new List<DepartmentsLesson>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
