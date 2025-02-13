﻿using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class Cart : BaseEntity
    {
        public List<Hamburger>? Hamburgers { get; set; }
        public List<ByProduct>? ByProducts { get; set; }
        public List<Extra>? Extras { get; set; }
        public List<Menu>? Menus { get; set; }
    }
}
