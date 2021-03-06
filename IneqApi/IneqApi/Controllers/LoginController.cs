﻿using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace IneqApi.Controllers
{
    public class LoginController : ApiController
    {
        private IneqApiContext db = new IneqApiContext();

        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        private ActionResult View(List<Models.User> list)
        {
            throw new NotImplementedException();
        }

        public ActionResult Login()
        {
            return View();
        }

        private ActionResult View()
        {
            throw new NotImplementedException();
        }

        public ActionResult Login(User user)
        {
            var e = db.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();

                if (e != null)
                {
                    e.ID.ToString();
                    e.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "El usuario o la contraseña estan equivocados. Confirme si los datos estan correctos.");
                }
                return View();
            

        }

        private ActionResult RedirectToAction(string p)
        {
            throw new NotImplementedException();
        }

        public ActionResult LoggedIn(int Id)
        {
            if (Id != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //
        //
        // GET api/login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/login
        public void Post([FromBody]string value)
        {
        }

        // PUT api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/login/5
        public void Delete(int id)
        {
        }
    }
}
