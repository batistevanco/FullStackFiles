using System;
using System.Collections.Generic;

namespace Canteen.Domain.EntitiesDB;

public partial class OrderLine
{
    public int OrderLineId { get; set; }

    public int OrderId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal PriceAtOrder { get; set; }

    public virtual Order Order { get; set; } = null!;
}
