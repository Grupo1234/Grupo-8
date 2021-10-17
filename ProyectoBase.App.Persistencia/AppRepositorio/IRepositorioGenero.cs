using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;


namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public interface IRepositorioGenero
    {
        
        Genero AddGenero(Genero genero);
        IEnumerable<Genero> GetAllGeneros(string? nombre);         
        Genero GetGenero(int? idGenero);
        Genero UpdateGenero(Genero genero);
        void DeleteGenero(int idGenero);

    }
    



}