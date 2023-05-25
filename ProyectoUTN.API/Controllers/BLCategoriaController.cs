using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoUTN.Modelos;

namespace ProyectoUTN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLCategoriaController : ControllerBase
    {
        private readonly DataContext _context;

        public BLCategoriaController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BLCategoria
        [Route("/BL/PrecioTotal_DelProducto")]
        [HttpGet]
        public ActionResult<double> PrecioTotal_DelProducto(int Id)
        {
            if (_context.Categorias == null)
            {
                return NotFound();
            }

            //var categoriaId = 1; // ID de la categoría que deseas obtener el precio total
            // var precioTotal = _context.Categorias
            //    .Where(c => c.Id == categoriaId) // Filtrar por la categoría deseada
            //  .Join(_context.Productos,
            //       c => c.Id,
            //       p => p.CategoriaId,
            //       (c, p) => p.Precio * p.Cantidad) // Multiplicar precio por cantidad
            //              .Sum(); // Sumar los resultados

              // var categoriaId = 2; // ID de la categoría que deseas obtener el precio total
              //  var precioTotal = _context.Categorias
             //   .Where(c => c.CodigoCategoria == categoriaId) // Filtrar por la categoría deseada
            //    .Join(_context.Productos,
              //        c => c.CodigoCategoria,
              //        p => p.Id,
             //         (c, p) => p.precio * p.Cantidad) // Multiplicar precio por cantidad
             //   .Sum(); // Sumar los resultados
            //    var categoriaId = 4; // ID de la categoría que deseas obtener el precio total
             // var precioTotal = (from c in _context.Categorias
                     //  join p in _context.Productos on c.CodigoCategoria equals p.Id
                     //  where c.CodigoCategoria == categoriaId
                     //  select p.precio * p.Cantidad)
                     // .Sum();
            var categoriaId = Id; // ID de la categoría que deseas obtener el precio total
            var precioTotal = _context.Productos
                .Where(p => p.Id == categoriaId) // Filtrar por la categoría deseada
                .Sum(p => p.precio * p.Cantidad); // Multiplicar precio por cantidad y sumar los resultados



            return precioTotal;
        }


    }
}