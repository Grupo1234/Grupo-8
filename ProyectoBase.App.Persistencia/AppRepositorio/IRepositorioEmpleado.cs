using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;


namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public interface IRepositorioEmpleado
    {
        
        Empleado AddEmpleado(Empleado empleado);
        IEnumerable<Empleado> GetAllEmpleados(string? nombre);         
        Empleado GetEmpleado(int? idEmpleado);
        Empleado UpdateEmpleado(Empleado empleado);
        void DeleteEmpleado(int idEmpleado);

    }
    



}