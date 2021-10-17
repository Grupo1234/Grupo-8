using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;



namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public class RepositorioGenero : IRepositorioGenero
    {
        private readonly AppContext _appContext;
        public IEnumerable<Genero> genero {get; set;} 

       public RepositorioGenero(AppContext appContext)
        {
            _appContext = appContext;
        }
        //AQUÍ CADA UNO DE LOS MÉTODOS DEL CRUD, REFERENCIADOS EN LA INTERFACE
         //SIGUIENTE DIAPOSITIVA

        Genero IRepositorioGenero.AddGenero(Genero genero)
        {
          try
          {
            var GeneroAdicionado = _appContext.Genero.Add( genero ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return GeneroAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Genero> IRepositorioGenero.GetAllGeneros(string? nombre)
        {
            if (nombre != null) {
              genero = _appContext.Genero.Where(p => p.nombre.Contains(nombre));
            }
            else 
               genero = _appContext.Genero;
            return genero;
        }

       Genero IRepositorioGenero.GetGenero(int? idGenero)
       {
            return _appContext.Genero.FirstOrDefault(p => p.id == idGenero);
       }

       Genero IRepositorioGenero.UpdateGenero(Genero genero)
        {
            var GeneroEncontrado = _appContext.Genero.FirstOrDefault(p => p.id == genero.id);
            if (GeneroEncontrado != null)
            {
                
                GeneroEncontrado.nombre    = genero.nombre;
                
                _appContext.SaveChanges();
            }
            return GeneroEncontrado;
        }

        void IRepositorioGenero.DeleteGenero(int idGenero)
        {
            var GeneroEncontrado = _appContext.Genero.FirstOrDefault(p => p.id == idGenero);
            if (GeneroEncontrado == null)
                return;
            _appContext.Genero.Remove(GeneroEncontrado);
            _appContext.SaveChanges();
        }

    }
}