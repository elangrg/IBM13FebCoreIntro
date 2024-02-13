using System;
using System.Collections.Generic;

namespace IBM13FebCoreIntro.Models;

public partial class EmployeeDept
{
    public int EmployeeId { get; set; }

    public string EmpName { get; set; } = null!;

    public decimal Salary { get; set; }

    public string DeptName { get; set; } = null!;
}
