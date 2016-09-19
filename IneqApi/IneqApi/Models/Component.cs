using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class Component
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int ComponentTypeId { get; set; }
        public int Equipment_Id { get; set; }
        public int EquipmentType_Id { get; set; }

    }
}