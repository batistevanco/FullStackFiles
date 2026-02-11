using System;
using System.Collections.Generic;

namespace ExamenTest.Domain.EntitiesDB;

public partial class Breweries2
{
    public int Brouwernr { get; set; }

    public string Naam { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public string Postcode { get; set; } = null!;

    public string Gemeente { get; set; } = null!;

    public decimal? Omzet { get; set; }

    public virtual ICollection<Beers2> Beers2s { get; set; } = new List<Beers2>();
}
