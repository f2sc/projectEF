using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace projectEF.Models
{
    public class Tarea
    {
        //[Key]
        public Guid TareaId { get; set; }

        //[ForeignKey("CategoriaId")]
        public Guid CategoriaId { get; set; }

        //[Required]
        //[MaxLength(200)]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public Prioridad PrioridadTarea { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual Categoria Categoria { get; set; }

        //[NotMapped]
        public string Resumen {  get; set; }

        public Tarea()
        {
            Titulo = string.Empty;
            Descripcion = string.Empty;
            PrioridadTarea = new Prioridad();
            FechaCreacion = DateTime.MinValue;
            Categoria = new Categoria();
            Resumen = string.Empty;
        }
    }

    public enum Prioridad
    {
        Baja, 
        Media, 
        Alta
    }
}
