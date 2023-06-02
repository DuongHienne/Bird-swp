using System;
using System.Collections.Generic;

namespace BiTrap.Entities;

public partial class TbProduct
{
    public int ProductId { get; set; }

    public string Name { get; set; } =null!;

    public bool? Status { get; set; }

    public decimal Price { get; set; }

    public string? Decription { get; set; }

    public string? Detail { get; set; }

    public int? QuantitySold { get; set; }

    public string CateId { get; set; }

    public string? ShopId { get; set; }

    public int? Rate { get; set; }

    public byte[]? Video { get; set; }

    public byte[]? Image { get; set; }

    public virtual TbProductCategory Cate { get; set; }

    public virtual TbShop Shop { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();
}
