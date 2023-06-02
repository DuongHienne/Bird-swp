using System;
using System.Collections.Generic;

namespace BiTrap.Entities;

public partial class TbRevenue
{
    public int Id { get; set; }

    public string ShopId { get; set; } = null!;

    public int OrderId { get; set; }

    public virtual TbOrder Order { get; set; } = null!;

    public virtual TbShop Shop { get; set; } = null!;
}
