using System;
using System.Collections.Generic;

namespace vancoillie_batiste.Domain.EntitiesDB;

public partial class Genre
{
    public int GenreNr { get; set; }

    public string Genre1 { get; set; } = null!;

    public virtual ICollection<Liedje> Liedjes { get; set; } = new List<Liedje>();
}
