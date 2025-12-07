using System.ComponentModel.DataAnnotations;

namespace Mecanica.NET
{
    public class empleadoModel
    {
        public long id { get; set; }
        [Required(ErrorMessage = "El campo Cédula es requerido")]
        public string cedula { get; set; }
        [Required(ErrorMessage = "El campo Nombres es requerido")]
        public string nombres { get; set; }
        [Required(ErrorMessage = "El campo Apellidos es requerido")]
        public string apellidos { get; set; }
        public string? correo { get; set; }
        public string? telefono { get; set; }
        [Required(ErrorMessage = "El campo Cargo es requerido")]
        public string cargo { get; set; }
        public int estado { get; set; }
    }
}