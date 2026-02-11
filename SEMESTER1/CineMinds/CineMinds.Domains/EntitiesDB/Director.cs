using System;
using System.Collections.Generic;

namespace CineMinds.Domains.EntitiesDB;

public partial class Director
{
    public int DirectorId { get; set; }

    public string FullName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
