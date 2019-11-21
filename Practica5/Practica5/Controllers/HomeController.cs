using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica5.Models;
using Practica5.Controllers;
using Practica5.Models.ViewModels;

namespace Practica5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //agracion de mis metodos
        public ActionResult Agenda()
        {
            List<ListTablaViewModelAgenda> lst;
            using (practica5Entities1 db = new practica5Entities1())
            {
                 lst = (from d in db.agenda
                          select new ListTablaViewModelAgenda
                          {
                              id_agenda = d.id_agenda,
                              nombre = d.nombre,
                              email = d.email,
                              direccion = d.direccion
                          }).ToList();

            }

                ViewBag.Message = "Esta es el formulario de la agenda";

            return View(lst);
        }

        public ActionResult Evento()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    
        
       

    }
}