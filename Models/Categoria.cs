using System.ComponentModel.DataAnnotations;

namespace projectEF.Models
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaID { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }

        public Categoria()
        {
            Nombre = string.Empty;  
            Descripcion = string.Empty;  
            Tareas = new List<Tarea>();  
        }
    }
}
