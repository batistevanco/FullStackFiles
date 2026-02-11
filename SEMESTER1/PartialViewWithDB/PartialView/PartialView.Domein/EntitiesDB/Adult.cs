using System;
using System.Collections.Generic;

namespace PartialView.Domein.EntitiesDB;

public partial class Adult
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime EnrollDate { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
}
