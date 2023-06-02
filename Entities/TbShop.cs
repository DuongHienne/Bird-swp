using System;
using System.Collections.Generic;

namespace BiTrap.Entities;

public partial class TbShop
{
    public string ShopId { get; set; } = null!;

    public int? Rate { get; set; }

    public string ShopName { get; set; } = null!;

    public string? Description { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<TbProduct> TbProducts { get; set; } = new List<TbProduct>();

    public virtual ICollection<TbRevenue> TbRevenues { get; set; } = new List<TbRevenue>();

    public virtual ICollection<TbWarehouse> TbWarehouses { get; set; } = new List<TbWarehouse>();

    public virtual TbUser? User { get; set; }
}
