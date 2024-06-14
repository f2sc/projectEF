
namespace projectEF.Models
{
    public class Categoria
    {
        public Guid CategoriaID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }

        public int Peso { get; set; }
    }
}
