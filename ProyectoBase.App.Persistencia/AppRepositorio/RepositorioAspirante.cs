using System.Collections.Generic;
using System.Linq;
using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;



namespace ProyectoBase.App.Persistencia.AppRepositorio
{
    public class RepositorioAspirante : IRepositorioAspirante
    {
        private readonly AppContext _appContext;
        public IEnumerable<Aspirante> aspirante {get; set;} 

       public RepositorioAspirante(AppContext appContext)
        {
            _appContext = appContext;
        }
        //AQUÍ CADA UNO DE LOS MÉTODOS DEL CRUD, REFERENCIADOS EN LA INTERFACE
         //SIGUIENTE DIAPOSITIVA

        Aspirante IRepositorioAspirante.AddAspirante(Aspirante aspirante)
        {
          try
          {
            var AspiranteAdicionado = _appContext.Aspirante.Add( aspirante ); //INSERT en la BD
            _appContext.SaveChanges();                  
            return AspiranteAdicionado.Entity;
          }catch
          {
                throw;
          }
        }

        IEnumerable<Aspirante> IRepositorioAspirante.GetAllAspirantes(string? nombre)
        {
            if (nombre != null) {
              aspirante = _appContext.Aspirante.Where(p => p.nombre.Contains(nombre));
            }
            else 
               aspirante = _appContext.Aspirante;
            return aspirante;
        }

       Aspirante IRepositorioAspirante.GetAspirante(int? idAspirante)
       {
            return _appContext.Aspirante.FirstOrDefault(p => p.id == idAspirante);
       }

       Aspirante IRepositorioAspirante.UpdateAspirante(Aspirante aspirante)
        {
            var AspiranteEncontrado = _appContext.Aspirante.FirstOrDefault(p => p.id == aspirante.id);
            if (AspiranteEncontrado != null)
            {
                
                AspiranteEncontrado.nombre    = aspirante.nombre;
                AspiranteEncontrado.apellido = aspirante.apellido;
                AspiranteEncontrado.edad = aspirante.edad;
                AspiranteEncontrado.profesion = aspirante.profesion;
                AspiranteEncontrado.estadocivil = aspirante.estadocivil;
                AspiranteEncontrado.ciudad = aspirante.ciudad;

                
                _appContext.SaveChanges();
            }
            return AspiranteEncontrado;
        }

        void IRepositorioAspirante.DeleteAspirante(int idAspirante)
        {
            var AspiranteEncontrado = _appContext.Aspirante.FirstOrDefault(p => p.id == idAspirante);
            if (AspiranteEncontrado == null)
                return;
            _appContext.Aspirante.Remove(AspiranteEncontrado);
            _appContext.SaveChanges();
        }

    }
}