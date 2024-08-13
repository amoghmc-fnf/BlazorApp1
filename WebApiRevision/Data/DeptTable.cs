using System;
using System.Collections.Generic;

namespace WebApiRevision.Data;

public partial class DeptTable
{
    public int DeptId { get; set; }

    public string? DeptName { get; set; }

    public virtual ICollection<EmpTable> EmpTables { get; set; } = new List<EmpTable>();
}
