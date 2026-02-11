using System;
using System.Collections.Generic;

namespace ExamenTest.Domain.EntitiesDB;

public partial class Varieties2
{
    public int Soortnr { get; set; }

    public string Soortnaam { get; set; } = null!;

    public virtual ICollection<Beers2> Beers2s { get; set; } = new List<Beers2>();
}
