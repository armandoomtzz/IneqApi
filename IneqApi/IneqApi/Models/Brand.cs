﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Model> Model { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}