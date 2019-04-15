using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteMedico.Models
{

    [MetadataType(typeof(PaisesMetadados))]
    public partial class Paises
    {

    }

    public class PaisesMetadados
    {
        [Required(ErrorMessage = "Obrigatório informar País")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Sigla")]
        [StringLength(2)]
        public string Sigla { get; set; }
    }
}