using System;
using System.Collections.Generic;

namespace BiTrap.Entities;

public partial class TbWarehouse
{
    public int Id { get; set; }

    public string ShopId { get; set; } = null!;

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public string ProductName { get; set; } = null!;

    public virtual TbShop Shop { get; set; } = null!;
}
