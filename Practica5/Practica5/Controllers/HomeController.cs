﻿using System;
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
        public ActionResult Agenda(String dato, String tipo)
        {
            List<ListTablaViewModelAgenda> lst;
            using (practica5Entities1 db = new practica5Entities1())
            {
                if ((dato != null))
                {

                    lst = (from d in db.agenda
                           where ((d.nombre == dato) || (d.email == dato))
                           select new ListTablaViewModelAgenda
                           {
                               id_agenda = d.id_agenda,
                               nombre = d.nombre,
                               numero = d.numero,
                               email = d.email,
                               direccion = d.direccion
                           }).ToList();



                }
                else
                    lst = (from d in db.agenda
                           select new ListTablaViewModelAgenda
                           {
                               id_agenda = d.id_agenda,
                               nombre = d.nombre,
                               numero = d.numero,
                               email = d.email,
                               direccion = d.direccion
                           }).ToList();

            }

            ViewBag.Message = "Esta es el formulario de la agenda";

            return View(lst);
        }
        //Esta parte es para añadir un nuevo contacto
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
                        dncontactos.numero = modelAgenda.numero;
                        dncontactos.email = modelAgenda.email;
                        dncontactos.direccion = modelAgenda.direccion;

                        db.agenda.Add(dncontactos);
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
        // esta parte es para cargar los datos del contacto
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
        // Esta parte es para editar el contacto 
        [HttpPost]
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
        //Este action es para eliminar el contacto

        public ActionResult eliminarcontacto(int id)
        {

            using (practica5Entities1 db = new practica5Entities1())
            {
                var aagenda = db.agenda.Find(id);
                db.agenda.Remove(aagenda);
                db.SaveChanges();

            }

            return Redirect("~/Home/Agenda/");
        }
        // En esta parte se realizara la consulta
        public ActionResult buscarcontacto(String dato)
        {
            List<ListTablaViewModelAgenda> lst;
            using (practica5Entities1 db = new practica5Entities1())
            {


                lst = (from d in db.agenda
                       where d.nombre == dato
                       select new ListTablaViewModelAgenda
                       {
                           id_agenda = d.id_agenda,
                           nombre = d.nombre,
                           numero = d.numero,
                           email = d.email,
                           direccion = d.direccion
                       }).ToList();

            }

            ViewBag.Message = "Esta es el formulario de la agenda";

            return View(lst);

        }

      

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        //agracion de mis metodos
        public ActionResult Evento(String dato, String tipo)
        {
            List<ListViewModelEvento> lst;
            using (practica5Entities1 db = new practica5Entities1())
            {
                if ((dato != null))
                {

                    lst = (from d in db.evento
                           where ((d.evento1 == dato) || (d.fecha == dato))
                           select new ListViewModelEvento
                           {
                               id_evento  = d.id_evento,
                               evento1 = d.evento1,
                               fecha = d.fecha,
                               hora = d.hora,
                           }).ToList();



                }
                else
                    lst = (from d in db.evento
                           select new ListViewModelEvento
                           {
                               id_evento = d.id_evento,
                               evento1 = d.evento1,
                               fecha = d.fecha,
                               hora = d.hora,
                           }).ToList();

            }


            return View(lst);
        }

        // Añadir nuevo evento

        public ActionResult nuevoevento()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult nuevoevento(TablaViewModelEvento modelEvento)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    using (practica5Entities1 db = new practica5Entities1())
                    {
                        var dncontactos = new evento();
                      
                        dncontactos.evento1 = modelEvento.evento1;
                        dncontactos.fecha = modelEvento.fecha;
                        dncontactos.hora = modelEvento.hora;



                        db.evento.Add(dncontactos);
                        db.SaveChanges();

                    }

                    return Redirect("~/Home/Evento/");
                }
                return View(modelEvento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}