using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;


namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public interface IRepositorioAspirante
    {
        
        Aspirante AddAspirante(Aspirante aspirante);
        IEnumerable<Aspirante> GetAllAspirantes(string? nombre);         
        Aspirante GetAspirante(int? idAspirante);
        Aspirante UpdateAspirante(Aspirante aspirante);
        void DeleteAspirante(int idAspirante);

    }
    



}