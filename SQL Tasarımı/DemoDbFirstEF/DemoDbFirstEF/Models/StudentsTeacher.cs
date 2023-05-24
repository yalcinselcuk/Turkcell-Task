using System;
using System.Collections.Generic;

namespace DemoDbFirstEF.Models;

public partial class StudentsTeacher
{
    public int Id { get; set; }

    public int? Studentid { get; set; }

    public int? Teacherid { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
