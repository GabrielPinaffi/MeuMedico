using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteMedico.Models
{
    [MetadataType(typeof(EstadosMetadados))]
    public partial class Estados
    {

    }

    public class EstadosMetadados
    {
        [Required(ErrorMessage = "Obrigatório informar Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Sigla")]
        [StringLength(2)]
        public string Sigla { get; set; }
    }
}