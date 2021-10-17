using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;


namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public interface IRepositorioAgencia
    {
        
        Agencia AddAgencia(Agencia agencia);
        IEnumerable<Agencia> GetAllAgencias(string? nombre);         
        Agencia GetAgencia(int? idAgencia);
        Agencia UpdateAgencia(Agencia agencia);
        void DeleteAgencia(int idAgencia);

    }
    



}