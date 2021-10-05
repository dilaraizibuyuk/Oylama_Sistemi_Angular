using oylamaproje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace oylamaproje.Controllers
{
    [System.Web.Mvc.Route("api/[controller]")]
    public class AuthController : ApiController
    {
        private oylamaprojedbEntities db;
        public AuthController()
        {
            db = new oylamaprojedbEntities();
        }
      //  [System.Web.Http.HttpPost("login")]
        public bool Login(UserForLoginModel userForLoginModel)
        {
            var uye = db.Uye.FirstOrDefault(u => u.E_mail == userForLoginModel.Email && u.Sifre == userForLoginModel.Sifre);
            if (uye!=null)
            {
                return true;
            }
            return false;
        }
        [System.Web.Http.HttpPost]
        public void Register(Uye uye)
        {
            db.Uye.Add(uye);
            db.SaveChanges();
        }
    }
}
