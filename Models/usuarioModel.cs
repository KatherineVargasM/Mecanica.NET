using System.ComponentModel.DataAnnotations;

namespace Mecanica.NET
{
    public class usuarioModel
    {
        public long id { get; set; }
        [Required(ErrorMessage = "El campo Nombre de Usuario es requerido")]
        public string nombre_usuario { get; set; }
        public long id_rol { get; set; }
    }
}