using System.ComponentModel.DataAnnotations;

namespace Mecanica.NET
{
    public class vehiculoModel
    {
        public long id { get; set; }
        public long id_cliente { get; set; }
        [Required(ErrorMessage = "El campo Marca es requerido")]
        public string marca { get; set; }
        [Required(ErrorMessage = "El campo Modelo es requerido")]
        public string modelo { get; set; }
        public int anio { get; set; }
        [Required(ErrorMessage = "El campo Tipo de Motor es requerido")]
        public string tipo_motor { get; set; }
        public DateTime? fecha_creacion { get; set; }
    }
}