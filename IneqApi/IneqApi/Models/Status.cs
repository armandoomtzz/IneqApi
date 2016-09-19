using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class Status
    {

        public int Id { get; set; }
        public String Description { get; set; }
        public Boolean Active { get; set; }




        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}