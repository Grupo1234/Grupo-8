using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;



namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public class RepositorioCiudad : IRepositorioCiudad
    {
        private readonly AppContext _appContext;
        public IEnumerable<Ciudad> ciudad {get; set;} 

       public RepositorioCiudad(AppContext appContext)
        {
            _appContext = appContext;
        }
        //AQUÍ CADA UNO DE LOS MÉTODOS DEL CRUD, REFERENCIADOS EN LA INTERFACE
         //SIGUIENTE DIAPOSITIVA

        Ciudad IRepositorioCiudad.AddCiudad(Ciudad ciudad)
        {
          try
          {
            var CiudadAdicionado = _appContext.Ciudad.Add( ciudad ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return CiudadAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Ciudad> IRepositorioCiudad.GetAllCiudades(string? nombre)
        {
            if (nombre != null) {
              ciudad = _appContext.Ciudad.Where(p => p.nombre.Contains(nombre));
            }
            else 
               ciudad = _appContext.Ciudad;
            return ciudad;
        }

       Ciudad IRepositorioCiudad.GetCiudad(int? idCiudad)
       {
            return _appContext.Ciudad.FirstOrDefault(p => p.id == idCiudad);
       }

       Ciudad IRepositorioCiudad.UpdateCiudad(Ciudad ciudad)
        {
            var CiudadEncontrado = _appContext.Ciudad.FirstOrDefault(p => p.id == ciudad.id);
            if (CiudadEncontrado != null)
            {
                
                CiudadEncontrado.nombre    = ciudad.nombre;
                
                _appContext.SaveChanges();
            }
            return CiudadEncontrado;
        }

        void IRepositorioCiudad.DeleteCiudad(int idCiudad)
        {
            var CiudadEncontrado = _appContext.Ciudad.FirstOrDefault(p => p.id == idCiudad);
            if (CiudadEncontrado == null)
                return;
            _appContext.Ciudad.Remove(CiudadEncontrado);
            _appContext.SaveChanges();
        }

    }
}