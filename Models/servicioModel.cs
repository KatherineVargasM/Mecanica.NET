using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mecanica.NET
{
    public class servicioModel
    {
        public long id { get; set; }
        [Required(ErrorMessage = "El campo Vehículo es requerido")]
        public long id_vehiculo { get; set; }
        [Required(ErrorMessage = "El campo Usuario es requerido")]
        public long id_usuario { get; set; }
        public DateTime? fecha_servicio { get; set; }

        [ForeignKey("id_vehiculo")]
        public vehiculoModel Vehiculo { get; set; }

        [ForeignKey("id_usuario")]
        public usuarioModel Usuario { get; set; }
    }
}