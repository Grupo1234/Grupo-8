using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoBase.App.Dominio;

using ProyectoBase.App.Persistencia.AppRepositorio;
using ProyectoBase.App.Persistencia;

namespace ProyectoBase.App.Presentacion.Pages.Estadosciviles
{
    //[Authorize]
    public class ListModel : PageModel
    {
        private readonly IRepositorioEstadocivil _appContext;
        public IEnumerable<Estadocivil> estadosciviles {get; set;} 

        public string searchString;     

        public ListModel()
        {
            this._appContext = new RepositorioEstadocivil(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        public void OnGet()
        {
            estadosciviles =_appContext.GetAllEstadosciviles(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            estadosciviles = _appContext.GetAllEstadosciviles(searchString);
            return Page();
        }
    }
}
