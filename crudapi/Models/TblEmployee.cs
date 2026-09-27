using System;
using System.Collections.Generic;

namespace crudapi.Models;

public partial class TblEmployee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public decimal? Salary { get; set; }

    public string? Gender { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int DepartmentId { get; set; }

    public virtual TblDepartment Department { get; set; } = null!;
}
