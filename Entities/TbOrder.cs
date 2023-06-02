using System;
using System.Collections.Generic;

namespace BiTrap.Entities;

public partial class TbOrder
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public bool? Status { get; set; }

    public string AddressUser { get; set; } = null!;

    public string? UserName { get; set; }

    public int UserId { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Note { get; set; }

    public decimal? ContactPhone { get; set; }

    public string ShopId { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();

    public virtual TbRevenue? TbRevenue { get; set; }

    public virtual TbUser User { get; set; } = null!;
}
