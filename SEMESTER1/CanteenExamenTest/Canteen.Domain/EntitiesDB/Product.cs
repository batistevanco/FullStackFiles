using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Canteen.Domain.EntitiesDB;

public partial class Product
{
    public int ProductId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Range(0.1, 20)]

    public decimal Price { get; set; }

    [Required]

    public string Description { get; set; } = null!;

    public int CategoryId { get; set; }

    public bool IsVegetarian { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category Category { get; set; } = null!;
}
