using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoBase.App.Dominio;

using ProyectoBase.App.Persistencia.AppRepositorio;
using ProyectoBase.App.Persistencia;

namespace ProyectoBase.App.Presentacion.Pages.Ciudades
{
    //[Authorize]
    public class ListModel : PageModel
    {
        private readonly IRepositorioCiudad _appContext;
        public IEnumerable<Ciudad> ciudades {get; set;} 

        public string searchString;     

        public ListModel()
        {
            this._appContext = new RepositorioCiudad(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        public void OnGet()
        {
            ciudades =_appContext.GetAllCiudades(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            ciudades = _appContext.GetAllCiudades(searchString);
            return Page();
        }
    }
}
