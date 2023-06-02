using System;
using System.Collections.Generic;

namespace BiTrap.Entities;

public partial class TbUser
{
    public DateTime? Dob { get; set; }

    public string? Gender { get; set; }

    public int UserId { get; set; }

    public string? Email { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal? Phone { get; set; }

    public string RoleId { get; set; } = null!;

    public DateTime? UpdateDate { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Address { get; set; }

    public byte[]? Avatar { get; set; }

    public virtual TbRole Role { get; set; } = null!;

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();

    public virtual TbShop? TbShop { get; set; }
}
