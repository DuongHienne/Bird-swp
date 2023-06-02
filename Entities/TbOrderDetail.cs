using System;
using System.Collections.Generic;

namespace BiTrap.Entities;

public partial class TbOrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal TotalPrice { get; set; }

    public int? Quantity { get; set; }

    public int? Discount { get; set; }

    public int Id { get; set; }

    public virtual TbOrder Order { get; set; } = null!;

    public virtual TbProduct Product { get; set; } = null!;
}
