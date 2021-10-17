using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;



namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public class RepositorioEstadocivil : IRepositorioEstadocivil
    {
        private readonly AppContext _appContext;
        public IEnumerable<Estadocivil> estadocivil {get; set;} 

       public RepositorioEstadocivil(AppContext appContext)
        {
            _appContext = appContext;
        }
        //AQUÍ CADA UNO DE LOS MÉTODOS DEL CRUD, REFERENCIADOS EN LA INTERFACE
         //SIGUIENTE DIAPOSITIVA

        Estadocivil IRepositorioEstadocivil.AddEstadocivil(Estadocivil estadocivil)
        {
          try
          {
            var EstadocivilAdicionado = _appContext.Estadocivil.Add( estadocivil ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return EstadocivilAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Estadocivil> IRepositorioEstadocivil.GetAllEstadosciviles(string? nombre)
        {
            if (nombre != null) {
              estadocivil = _appContext.Estadocivil.Where(p => p.nombre.Contains(nombre));
            }
            else 
               estadocivil = _appContext.Estadocivil;
            return estadocivil;
        }

       Estadocivil IRepositorioEstadocivil.GetEstadocivil(int? idEstadocivil)
       {
            return _appContext.Estadocivil.FirstOrDefault(p => p.id == idEstadocivil);
       }

       Estadocivil IRepositorioEstadocivil.UpdateEstadocivil(Estadocivil estadocivil)
        {
            var EstadocivilEncontrado = _appContext.Estadocivil.FirstOrDefault(p => p.id == estadocivil.id);
            if (EstadocivilEncontrado != null)
            {
                
                EstadocivilEncontrado.nombre    = estadocivil.nombre;
                
                _appContext.SaveChanges();
            }
            return EstadocivilEncontrado;
        }

        void IRepositorioEstadocivil.DeleteEstadocivil(int idEstadocivil)
        {
            var EstadocivilEncontrado = _appContext.Estadocivil.FirstOrDefault(p => p.id == idEstadocivil);
            if (EstadocivilEncontrado == null)
                return;
            _appContext.Estadocivil.Remove(EstadocivilEncontrado);
            _appContext.SaveChanges();
        }

    }
}