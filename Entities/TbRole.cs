﻿using System;
using System.Collections.Generic;

namespace BiTrap.Entities;

public partial class TbRole
{
    public string RoleId { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public virtual ICollection<TbUser> TbUsers { get; set; } = new List<TbUser>();
}
