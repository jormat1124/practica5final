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
        public ActionResult nuevocontacto()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [HttpPost]
        public ActionResult nuevocontacto(TablaViewModelAgenda modelAgenda)
        {
            try
            {
                if (ModelState.IsValid)
            
                {
                    using (practica5Entities1 db = new practica5Entities1())
                    { 
                        var dncontactos = new agenda();
                        dncontactos.id_agenda = modelAgenda.id_agenda;
                        dncontactos.nombre = modelAgenda.nombre;
                        dncontactos.email = modelAgenda.email;
                        dncontactos.direccion = modelAgenda.direccion;

                        db.agenda.Add(dncontactos);
                        db.SaveChanges();
                        
                    }

                    return Redirect("~/Home/Agenda/");
                }
                return View(modelAgenda);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult editarcontacto(int id)
        {
            TablaViewModelAgenda modelagendaeditar = new TablaViewModelAgenda();
            using (practica5Entities1 db = new practica5Entities1())
            {
                var agenda = db.agenda.Find(id);
                modelagendaeditar.id_agenda = agenda.id_agenda;
                modelagendaeditar.nombre = agenda.nombre;
                modelagendaeditar.email = agenda.email;
                modelagendaeditar.direccion = agenda.direccion;


            }

            return View(modelagendaeditar);
        }

        [HttpPost ]
        public ActionResult editarcontacto(TablaViewModelAgenda modelAgenda)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    using (practica5Entities1 db = new practica5Entities1())
                    {
                        var dncontactos = db.agenda.Find(modelAgenda.id_agenda);
                        dncontactos.id_agenda = modelAgenda.id_agenda;
                        dncontactos.nombre = modelAgenda.nombre;
                        dncontactos.email = modelAgenda.email;
                        dncontactos.direccion = modelAgenda.direccion;

                        db.Entry(dncontactos).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }

                    return Redirect("~/Home/Agenda/");
                }
                return View(modelAgenda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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