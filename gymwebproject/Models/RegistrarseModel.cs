using System.ComponentModel.DataAnnotations;

namespace gymwebproject.Models
{
    public class RegistrarseModel
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        public string correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string contraseña { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        public Tiposexo Tiposexo { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        public string rol { get; set; }

    }
}
