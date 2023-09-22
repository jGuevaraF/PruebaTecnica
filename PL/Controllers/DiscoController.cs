using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        public ActionResult GetAll()
        {
            ML.Disco disco = new ML.Disco();
            ML.Result result = BL.Disco.GetAll();
            disco.Discos = result.Objects;
            return View(disco);
        }
    }
}