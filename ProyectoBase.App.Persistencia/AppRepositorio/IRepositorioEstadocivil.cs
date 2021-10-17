using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;


namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public interface IRepositorioEstadocivil
    {
        
        Estadocivil AddEstadocivil(Estadocivil estadocivil);
        IEnumerable<Estadocivil> GetAllEstadosciviles(string? nombre);         
        Estadocivil GetEstadocivil(int? idEstadocivil);
        Estadocivil UpdateEstadocivil(Estadocivil estadocivil);
        void DeleteEstadocivil(int idEstadocivil);

    }
    



}