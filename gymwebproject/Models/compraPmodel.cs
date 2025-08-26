using System.ComponentModel.DataAnnotations;

namespace gymwebproject.Models
{
    public class compraPmodel
    {
        public int Id { get; set; }
        public string nombre { get; set; }

        public string correo { get; set; }

        public string suscripcion { get; set; }

        public decimal precio { get; set; }

        public string metodo { get; set; }

        public decimal numero { get; set;}

        public string tarjeta { get; set; }

        public string estado { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; } = DateTime.Now;


    }
}
