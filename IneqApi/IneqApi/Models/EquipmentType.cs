using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class EquipmentType
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public float UsefulLife { get; set; }
        public float GuaranteeDuration { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }

    }
}