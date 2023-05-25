using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoUTN.Modelos
{
    public class Producto
    {
        public int Id { get; set; } // pk
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double precio { get; set; }

        // relacion

        public int CategoriaId { get; set; }  // fk
        public Categoria? Categoria { get; set; }
        

    }
}
    
