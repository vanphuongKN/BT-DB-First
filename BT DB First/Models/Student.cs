using System;
using System.Collections.Generic;

namespace BT_DB_First.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }
}
