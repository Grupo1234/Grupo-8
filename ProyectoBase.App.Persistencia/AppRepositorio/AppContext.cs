using Microsoft.EntityFrameworkCore;
using ProyectoBase.App.Dominio;



namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public class AppContext : DbContext

    {
        public DbSet<Agencia> Agencia { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Ciudad> Ciudad{ get; set; }
        public DbSet<Estadocivil> Estadocivil{ get; set; }
        public DbSet<Genero> Genero{ get; set; }
        public DbSet<Profesion> Profesion{ get; set; }
        public DbSet<Empresa> Empresa{ get; set; }
        public DbSet<Aspirante> Aspirante{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
    //"Data Source = server234.database.windows.net; Initial Catalog =ProyectoBase1; User ID=ciclo3; Password="
               .UseSqlServer("Server=server234.database.windows.net; Database=default; user id=ciclo3; password=BaseDatos*; Initial Catalog = ProyectoBase1");
            } 
         }

         }
}