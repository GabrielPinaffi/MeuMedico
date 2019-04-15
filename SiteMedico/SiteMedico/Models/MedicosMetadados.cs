    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteMedico.Models
{
    [MetadataType(typeof(MedicoMetadados))]
    public partial class Medicos
    {

    }

    public class MedicoMetadados
    {
        [Required(ErrorMessage = "Obrigatório informar CRM")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Cidade")]
        public string CidadeId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Especialidade")]
        public string EspecialidadeId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Email")]

        public string Email { get; set; }

        public bool AtendePorConvenio { get; set; }
        public bool TemClinica { get; set; }

        public string WebsiteBlog { get; set; }
    }
}