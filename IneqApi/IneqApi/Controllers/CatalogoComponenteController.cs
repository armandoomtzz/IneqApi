using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IneqApi.Controllers
{
    public class CatalogoComponenteController : ApiController
    {
        private IneqApiContext db = new IneqApiContext();

        // GET api/catalogocomponente
        public List<ComponentType> Get()
        {
            return db.ComponentTypes.ToList();
        }

        // GET api/catalogocomponente/5
        public List<ComponentType> Get(int id)
        {
            return db.ComponentTypes.Where(e => e.ID == id).ToList();
        }

        // POST api/catalogocomponente
        public bool Post(int id, string description, bool active)
        {
            var e = new ComponentType
            {
                ID = id,
                Description = description,
                Active = active,
            };
            db.ComponentTypes.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT api/catalogocomponente/5
        public bool Put(int id, string description, bool active)
        {
            var componentType = new ComponentType
            {
                ID = id,
                Description = description,
                Active = active,
            };
            db.ComponentTypes.Add(componentType);
            return db.SaveChanges() > 0;
        }

        // DELETE api/catalogocomponente/5
        public void Delete(int id)
        {
            //En este caso de uso no se utilizara
        }
    }
}
