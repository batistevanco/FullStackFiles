using System;
using System.Collections.Generic;

namespace Canteen.Domain.EntitiesDB;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime? DateAdded { get; set; }

    public virtual Product Product { get; set; } = null!;
}
