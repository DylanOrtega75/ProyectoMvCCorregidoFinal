using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoUTN.Modelos;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }
            // No nos olvidemos de pluralizar ya que con estos nombres se crearan fisicamente en la BDD
        public DbSet<ProyectoUTN.Modelos.Producto> Productos { get; set; } = default!;

        public DbSet<ProyectoUTN.Modelos.Categoria>? Categorias { get; set; }
    }
