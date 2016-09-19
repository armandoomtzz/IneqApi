using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace IneqApi.Controllers
{
    public class BrandController : ApiController
    {
            private IneqApiContext db = new IneqApiContext();

        // GET: api/Brand
        public List<Brand> Get()
            {
                return db.Brands.ToList();
            }

        // GET: api/Brand/5
        public List<Brand> Get(int id)
            {
                return db.Brands.Where(e => e.ID == id).ToList();
            }

        // POST: api/Brand
        public bool Post(int id, string Description, bool Active)
            {
                var e = new Brand
                {
                    ID = id,
                    Description = Description,
                    Active = Active,
                };
                db.ComponentTypes.Attach(e);
                db.Configuration.ValidateOnSaveEnabled = true;
                return db.SaveChanges() > 0;
            }


            // PUT: api/Brand/5
            public bool Put(string Description, bool Active)
            {
                var Brand = new Brand
                {
                    Description = Description,
                    Active = Active,

                };
                db.Brands.Add(Brand);
                return db.SaveChanges() > 0;
            }

            // DELETE: api/Brand/5
            public bool Delete(int id)
            {
                var e = db.Brands.Find(id);
                db.Brands.Attach(e);
                db.Brands.Remove(e);
                return db.SaveChanges() > 0;
            }
        }
    }
