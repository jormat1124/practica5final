using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica5.Models.ViewModels
{
    public class TablaViewModelAgenda
    {

        [Required]
        [Display(Name = "Id Agenda")]
        public int id_agenda { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "nombre")]
        public string nombre { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]

        public string email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }


    }
}