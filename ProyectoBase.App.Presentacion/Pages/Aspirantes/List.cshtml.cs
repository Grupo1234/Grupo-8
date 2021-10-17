using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoBase.App.Dominio;

using ProyectoBase.App.Persistencia.AppRepositorio;
using ProyectoBase.App.Persistencia;

namespace ProyectoBase.App.Presentacion.Pages.Aspirantes
{
    //[Authorize]
    public class ListModel : PageModel
    {
        private readonly IRepositorioAspirante _appContext;
        public IEnumerable<Aspirante> aspirantes {get; set;} 

        public string searchString;     

        public ListModel()
        {
            this._appContext = new RepositorioAspirante(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        public void OnGet()
        {
            aspirantes =_appContext.GetAllAspirantes(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            aspirantes = _appContext.GetAllAspirantes(searchString);
            return Page();
        }
    }
}