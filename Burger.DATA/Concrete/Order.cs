﻿using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class Order : BaseEntity
    {
        public double TotalPrice { get; set; }

        //Nav

        public string UserId { get; set; }
        public virtual AppUser? AppUser { get; set; }

        public virtual ICollection<OrderHamburger>? OrderHamburgers { get; set; }
        public virtual ICollection<OrderMenu>? OrderMenus { get; set; }
        public virtual ICollection<OrderByProduct>? OrderByProducts { get; set; }
        public virtual ICollection<OrderExtra>? OrderExtras { get; set; }
    }
}
