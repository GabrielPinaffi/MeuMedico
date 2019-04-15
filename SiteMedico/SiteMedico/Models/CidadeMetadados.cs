using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteMedico.Models
{
    [MetadataType(typeof(CidadeMetadados))]
    public partial class Cidade
    {

    }

    public class CidadeMetadados
    {
        [Required(ErrorMessage = "Obrigatório informar Nome da Cidade")]
        public string Cidade { get; set; }
    }
}