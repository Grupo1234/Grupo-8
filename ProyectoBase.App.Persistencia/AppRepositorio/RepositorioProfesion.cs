using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;



namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public class RepositorioProfesion : IRepositorioProfesion
    {
        private readonly AppContext _appContext;
        public IEnumerable<Profesion> profesion {get; set;} 

       public RepositorioProfesion(AppContext appContext)
        {
            _appContext = appContext;
        }
        //AQUÍ CADA UNO DE LOS MÉTODOS DEL CRUD, REFERENCIADOS EN LA INTERFACE
         //SIGUIENTE DIAPOSITIVA

        Profesion IRepositorioProfesion.AddProfesion(Profesion profesion)
        {
          try
          {
            var ProfesionAdicionado = _appContext.Profesion.Add( profesion ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return ProfesionAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Profesion> IRepositorioProfesion.GetAllProfesiones(string? nombre)
        {
            if (nombre != null) {
              profesion = _appContext.Profesion.Where(p => p.nombre.Contains(nombre));
            }
            else 
               profesion = _appContext.Profesion;
            return profesion;
        }

       Profesion IRepositorioProfesion.GetProfesion(int? idProfesion)
       {
            return _appContext.Profesion.FirstOrDefault(p => p.id == idProfesion);
       }

       Profesion IRepositorioProfesion.UpdateProfesion(Profesion profesion)
        {
            var ProfesionEncontrado = _appContext.Profesion.FirstOrDefault(p => p.id == profesion.id);
            if (ProfesionEncontrado != null)
            {
                
                ProfesionEncontrado.nombre    = profesion.nombre;
                
                _appContext.SaveChanges();
            }
            return ProfesionEncontrado;
        }

        void IRepositorioProfesion.DeleteProfesion(int idProfesion)
        {
            var ProfesionEncontrado = _appContext.Profesion.FirstOrDefault(p => p.id == idProfesion);
            if (ProfesionEncontrado == null)
                return;
            _appContext.Profesion.Remove(ProfesionEncontrado);
            _appContext.SaveChanges();
        }

    }
}