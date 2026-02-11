using System;
using System.Collections.Generic;

namespace Canteen.Domain.EntitiesDB;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string CustomerName { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
