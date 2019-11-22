using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica5.Models.ViewModels
{
    public class TablaViewModelEvento
    {

        [Required]
        [Display(Name = "Id Evento")]
        public int id_evento { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Evento")]
        public string evento1 { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Fecha")]
        public string fecha { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Hora")]
        public string hora { get; set; }
    }
}