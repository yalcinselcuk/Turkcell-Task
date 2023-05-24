using System;
using System.Collections.Generic;

namespace DemoDbFirstEF.Models;

public partial class StudentsLesson
{
    public int Id { get; set; }

    public int? Studentid { get; set; }

    public int? Lessonid { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual Student? Student { get; set; }
}
