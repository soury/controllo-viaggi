using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Core.Authentication
{
    public class RegisterModel

    { 
        [Required(ErrorMessage = "Nome richiesto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Cognome richiesto")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Username richiesto")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password richiesto")]
        public string Password { get; set; }
    }
}
