﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudRestaurant.Shared.Models
{
    public class Menu
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set;}
    }
}