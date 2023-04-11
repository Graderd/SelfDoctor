using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Dtos.User
{
    public class UserInsertDto
    {
        [Required(ErrorMessage = "El Nombre de usuario es obligatorio")]
        [MaxLength(30, ErrorMessage = "El Nombre de usuario no debe de tener mas de 30 caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El Email de usuario es obligatorio")]
        [MaxLength(30, ErrorMessage = "El Email de usuario no debe de tener mas de 30 caracteres")]
        [EmailAddress(ErrorMessage = "Escribe un email valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatorai")]
        [MinLength(8, ErrorMessage = "Debes escribir 8 caracteres como minimo")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatorai")]
        [MinLength(8, ErrorMessage = "Debes escribir 8 caracteres como minimo")]
        public string ConfirmPassword { get; set; }
     }
}
