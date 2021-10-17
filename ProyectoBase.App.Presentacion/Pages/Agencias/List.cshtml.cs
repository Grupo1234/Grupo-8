using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoBase.App.Dominio;

using ProyectoBase.App.Persistencia.AppRepositorio;
using ProyectoBase.App.Persistencia;

namespace ProyectoBase.App.Presentacion.Pages.Agencias
{
    //[Authorize]
    public class ListModel : PageModel
    {
        private readonly IRepositorioAgencia _appContext;
        public IEnumerable<Agencia> agencias {get; set;} 

        public string searchString;     

        public ListModel()
        {
            this._appContext = new RepositorioAgencia(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        public void OnGet()
        {
            agencias =_appContext.GetAllAgencias(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            agencias = _appContext.GetAllAgencias(searchString);
            return Page();
        }
    }
}
