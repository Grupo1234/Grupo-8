using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;



namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public class RepositorioEmpleado : IRepositorioEmpleado
    {
        private readonly AppContext _appContext;
        public IEnumerable<Empleado> empleado {get; set;} 

       public RepositorioEmpleado(AppContext appContext)
        {
            _appContext = appContext;
        }
        //AQUÍ CADA UNO DE LOS MÉTODOS DEL CRUD, REFERENCIADOS EN LA INTERFACE
         //SIGUIENTE DIAPOSITIVA

        Empleado IRepositorioEmpleado.AddEmpleado(Empleado empleado)
        {
          try
          {
            var EmpleadoAdicionado = _appContext.Empleado.Add( empleado ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return EmpleadoAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Empleado> IRepositorioEmpleado.GetAllEmpleados(string? nombre)
        {
            if (nombre != null) {
              empleado = _appContext.Empleado.Where(p => p.nombre.Contains(nombre));
            }
            else 
               empleado = _appContext.Empleado;
            return empleado;
        }

       Empleado IRepositorioEmpleado.GetEmpleado(int? idEmpleado)
       {
            return _appContext.Empleado.FirstOrDefault(p => p.id == idEmpleado);
       }

       Empleado IRepositorioEmpleado.UpdateEmpleado(Empleado empleado)
        {
            var EmpleadoEncontrado = _appContext.Empleado.FirstOrDefault(p => p.id == empleado.id);
            if (EmpleadoEncontrado != null)
            {
                EmpleadoEncontrado.nombre       = empleado.nombre;
                EmpleadoEncontrado.apellido    = empleado.apellido;
                EmpleadoEncontrado.direccion = empleado.direccion;
                EmpleadoEncontrado.telefono = empleado.telefono;
                _appContext.SaveChanges();
            }
            return EmpleadoEncontrado;
        }

        void IRepositorioEmpleado.DeleteEmpleado(int idEmpleado)
        {
            var EmpleadoEncontrado = _appContext.Empleado.FirstOrDefault(p => p.id == idEmpleado);
            if (EmpleadoEncontrado == null)
                return;
            _appContext.Empleado.Remove(EmpleadoEncontrado);
            _appContext.SaveChanges();
        }

    }
}