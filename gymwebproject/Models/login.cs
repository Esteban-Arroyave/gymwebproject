using System.ComponentModel.DataAnnotations;

namespace gymwebproject.Models
{
    public class login
    {
        [Required(ErrorMessage = "El campo {0} requerido")]
        public string correo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string contraseña { get; set; }
    }
}
