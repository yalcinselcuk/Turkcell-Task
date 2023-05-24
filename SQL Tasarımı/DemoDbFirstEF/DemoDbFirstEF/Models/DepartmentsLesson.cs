using System;
using System.Collections.Generic;

namespace DemoDbFirstEF.Models;

public partial class DepartmentsLesson
{
    public int Id { get; set; }

    public int? Departmentid { get; set; }

    public int? Lessonid { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Lesson? Lesson { get; set; }
}
