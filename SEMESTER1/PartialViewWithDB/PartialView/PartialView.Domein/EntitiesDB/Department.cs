using System;
using System.Collections.Generic;

namespace PartialView.Domein.EntitiesDB;

public partial class Department
{
    public int Id { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Adult> Adults { get; set; } = new List<Adult>();
}
