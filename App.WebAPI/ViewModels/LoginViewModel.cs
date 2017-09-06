using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebAPI.ViewModels
{
    /// <summary>
    /// View Model para realização de Login
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Email usado para o login
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        [Required]
        public string Senha { get; set; }
        
    }
}
