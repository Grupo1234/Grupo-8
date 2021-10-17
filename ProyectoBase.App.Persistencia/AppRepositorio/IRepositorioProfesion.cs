using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;


namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public interface IRepositorioProfesion
    {
        
        Profesion AddProfesion(Profesion profesion);
        IEnumerable<Profesion> GetAllProfesiones(string? nombre);         
        Profesion GetProfesion(int? idProfesion);
        Profesion UpdateProfesion(Profesion profesion);
        void DeleteProfesion(int idProfesion);

    }
    



}