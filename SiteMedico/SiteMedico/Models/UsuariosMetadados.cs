using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteMedico.Models
{
    [MetadataType(typeof(UsuariosMetadados))]
    public partial class Usuarios
    {

    }

    public class UsuariosMetadados
    {
        [Required(ErrorMessage = "Obrigatório informar Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Email")]
        public string Email { get; set; }
    }
}