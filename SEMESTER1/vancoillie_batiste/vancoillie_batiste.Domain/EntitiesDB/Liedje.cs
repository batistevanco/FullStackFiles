using System;
using System.Collections.Generic;

namespace vancoillie_batiste.Domain.EntitiesDB;

public partial class Liedje
{
    public int SongNr { get; set; }

    public string? Artiest { get; set; }

    public string? Titel { get; set; }

    public int? Genrenr { get; set; }

    public string? Speelduur { get; set; }

    public int? Kostprijs { get; set; }

    public virtual Genre GenrenrNavigation { get; set; } = null!;
}
