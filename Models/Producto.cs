using System.ComponentModel.DataAnnotations;

namespace ProgramacionIV.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "Pon el nombre de a verga")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Pon la cantidad mmvrg")]
        public int Cantidad { get; set; }
    }
}
