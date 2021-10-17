using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;



namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        private readonly AppContext _appContext;
        public IEnumerable<Empresa> empresa {get; set;} 

       public RepositorioEmpresa(AppContext appContext)
        {
            _appContext = appContext;
        }
        //AQUÍ CADA UNO DE LOS MÉTODOS DEL CRUD, REFERENCIADOS EN LA INTERFACE
         //SIGUIENTE DIAPOSITIVA

        Empresa IRepositorioEmpresa.AddEmpresa(Empresa empresa)
        {
          try
          {
            var EmpresaAdicionado = _appContext.Empresa.Add( empresa ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return EmpresaAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Empresa> IRepositorioEmpresa.GetAllEmpresas(string? nombre)
        {
            if (nombre != null) {
              empresa = _appContext.Empresa.Where(p => p.nombre.Contains(nombre));
            }
            else 
               empresa = _appContext.Empresa;
            return empresa;
        }

       Empresa IRepositorioEmpresa.GetEmpresa(int? idEmpresa)
       {
            return _appContext.Empresa.FirstOrDefault(p => p.id == idEmpresa);
       }

       Empresa IRepositorioEmpresa.UpdateEmpresa(Empresa empresa)
        {
            var EmpresaEncontrado = _appContext.Empresa.FirstOrDefault(p => p.id == empresa.id);
            if (EmpresaEncontrado != null)
            {
                EmpresaEncontrado.nit       = empresa.nit;
                EmpresaEncontrado.nombre    = empresa.nombre;
                EmpresaEncontrado.telefono    = empresa.telefono;
                EmpresaEncontrado.direccion = empresa.direccion;
                EmpresaEncontrado.ciudad = empresa.ciudad;
                _appContext.SaveChanges();
            }
            return EmpresaEncontrado;
        }

        void IRepositorioEmpresa.DeleteEmpresa(int idEmpresa)
        {
            var EmpresaEncontrado = _appContext.Empresa.FirstOrDefault(p => p.id == idEmpresa);
            if (EmpresaEncontrado == null)
                return;
            _appContext.Empresa.Remove(EmpresaEncontrado);
            _appContext.SaveChanges();
        }

    }
}