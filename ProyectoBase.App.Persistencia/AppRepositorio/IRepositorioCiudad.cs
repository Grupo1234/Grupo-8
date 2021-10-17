using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;


namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public interface IRepositorioCiudad
    {
        
        Ciudad AddCiudad(Ciudad ciudad);
        IEnumerable<Ciudad> GetAllCiudades(string? nombre);         
        Ciudad GetCiudad(int? idCiudad);
        Ciudad UpdateCiudad(Ciudad ciudad);
        void DeleteCiudad(int idCiudad);

    }
    



}