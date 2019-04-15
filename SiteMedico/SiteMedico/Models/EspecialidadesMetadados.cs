using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteMedico.Models
{
    [MetadataType(typeof(EspecialidadesMetadados))]
    public partial class Especialidades
    {

    }

    public class EspecialidadesMetadados
    {
        [Required(ErrorMessage = "Obrigatório informar Especialidade")]
        public string Especialidade { get; set; }
        
    }
}