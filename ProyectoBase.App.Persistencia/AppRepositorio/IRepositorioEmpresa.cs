using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;


namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public interface IRepositorioEmpresa
    {
        
        Empresa AddEmpresa(Empresa empresa);
        IEnumerable<Empresa> GetAllEmpresas(string? nombre);         
        Empresa GetEmpresa(int? idEmpresa);
        Empresa UpdateEmpresa(Empresa empresa);
        void DeleteEmpresa(int idEmpresa);

    }
    



}