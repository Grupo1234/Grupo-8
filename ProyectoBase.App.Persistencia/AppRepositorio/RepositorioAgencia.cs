using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;



namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private readonly AppContext _appContext;
        public IEnumerable<Agencia> agencia {get; set;} 

       public RepositorioAgencia(AppContext appContext)
        {
            _appContext = appContext;
        }
        //AQUÍ CADA UNO DE LOS MÉTODOS DEL CRUD, REFERENCIADOS EN LA INTERFACE
         //SIGUIENTE DIAPOSITIVA

        Agencia IRepositorioAgencia.AddAgencia(Agencia agencia)
        {
          try
          {
            var AgenciaAdicionado = _appContext.Agencia.Add( agencia ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return AgenciaAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Agencia> IRepositorioAgencia.GetAllAgencias(string? nombre)
        {
            if (nombre != null) {
              agencia = _appContext.Agencia.Where(p => p.nombre.Contains(nombre));
            }
            else 
               agencia = _appContext.Agencia;
            return agencia;
        }

       Agencia IRepositorioAgencia.GetAgencia(int? idAgencia)
       {
            return _appContext.Agencia.FirstOrDefault(p => p.id == idAgencia);
       }

       Agencia IRepositorioAgencia.UpdateAgencia(Agencia agencia)
        {
            var AgenciaEncontrado = _appContext.Agencia.FirstOrDefault(p => p.id == agencia.id);
            if (AgenciaEncontrado != null)
            {
                AgenciaEncontrado.nit       = agencia.nit;
                AgenciaEncontrado.nombre    = agencia.nombre;
                AgenciaEncontrado.direccion = agencia.direccion;
                _appContext.SaveChanges();
            }
            return AgenciaEncontrado;
        }

        void IRepositorioAgencia.DeleteAgencia(int idAgencia)
        {
            var AgenciaEncontrado = _appContext.Agencia.FirstOrDefault(p => p.id == idAgencia);
            if (AgenciaEncontrado == null)
                return;
            _appContext.Agencia.Remove(AgenciaEncontrado);
            _appContext.SaveChanges();
        }

    }
}