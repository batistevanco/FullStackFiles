using System;
using System.Collections.Generic;

namespace ExamenTest.Domain.EntitiesDB;

public partial class Beers2
{
    public int Biernr { get; set; }

    public string Naam { get; set; } = null!;

    public int Brouwernr { get; set; }

    public int Soortnr { get; set; }

    public decimal? Alcohol { get; set; }

    public string? Image { get; set; }

    public virtual Breweries2 BrouwernrNavigation { get; set; } = null!;

    public virtual Varieties2 SoortnrNavigation { get; set; } = null!;
}
