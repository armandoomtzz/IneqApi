using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IneqApi.Controllers
{
    public class ComponentTypeController : ApiController
    {
        private IneqApiContext db = new IneqApiContext();
        // GET: api/ComponentType
        public List<ComponentType> Get()
        {
            return db.ComponentTypes.ToList();
        }

        // GET: api/ComponentType/5
        public List<ComponentType> Get(int id)
        {
            return db.ComponentTypes.Where(e => e.ID == id).ToList();
        }

        // POST: api/ComponentType
        public bool Post(int id, string Description, bool Active)
        {
            var e = new ComponentType
            {
                ID = id,
                Description = Description,
                Active = Active,
            };
            db.ComponentTypes.Attach(e);
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }


        // PUT: api/ComponentType/5
        public bool Put(string Description, bool Active)   
        {
            var componenttype = new ComponentType
            {
                Description = Description,
                Active = Active,

            };
            db.ComponentTypes.Add(componenttype);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/ComponentType/5
        public bool Delete(int id)
        {
            var e = db.ComponentTypes.Find(id);
            db.ComponentTypes.Attach(e);
            db.ComponentTypes.Remove(e);
            return db.SaveChanges() > 0;
        }
    }
}
