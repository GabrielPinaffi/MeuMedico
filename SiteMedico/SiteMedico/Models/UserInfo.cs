using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteMedico.Models
{
    public class UserInfo
    {
        public int cod { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string email { get; set; }

        public UserInfo()
        {
        }

        public UserInfo(int cod, string name, string login, string senha, string email)
        {
            this.cod = cod;
            this.name = name;
            this.login = login;
            this.senha = senha;
            this.email = email;
        }
    }
}