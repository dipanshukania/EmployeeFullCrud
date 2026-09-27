using System;
using System.Collections.Generic;

namespace crudapi.Models;

public partial class TblDepartment
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<TblEmployee> TblEmployees { get; set; } = new List<TblEmployee>();
}
