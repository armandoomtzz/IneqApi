using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class ComponentType
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }


        public virtual Component Components { get; set; }

    }
}