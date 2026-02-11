using System;
using System.Collections.Generic;

namespace CineMinds.Domains.EntitiesDB;

public partial class WatchlistItem
{
    public int WatchlistItemId { get; set; }

    public int MovieId { get; set; }

    public DateTime? DateAdded { get; set; }

    public virtual Movie Movie { get; set; } = null!;
}
