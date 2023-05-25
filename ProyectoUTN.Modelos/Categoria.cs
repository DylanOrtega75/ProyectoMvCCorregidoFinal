using System.ComponentModel.DataAnnotations;

namespace ProyectoUTN.Modelos
{
    public class Categoria
    {
        [Key]  // designamos PK
        public int Id { get; set; } //pk
        public string Nombre { get; set; }


        // relacion
        
        public List<Producto>? Productos { get; set; }
        
    }
}
