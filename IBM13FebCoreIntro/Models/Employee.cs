using System;
using System.Collections.Generic;

namespace IBM13FebCoreIntro.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmpName { get; set; } = null!;

    public decimal Salary { get; set; }
}
