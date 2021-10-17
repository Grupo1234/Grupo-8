using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoBase.App.Dominio;

using ProyectoBase.App.Persistencia.AppRepositorio;
using ProyectoBase.App.Persistencia;

namespace ProyectoBase.App.Presentacion.Pages.Empresas
{
    //[Authorize]
    public class ListModel : PageModel
    {
        private readonly IRepositorioEmpresa _appContext;
        public IEnumerable<Empresa> empresas {get; set;} 

        public string searchString;     

        public ListModel()
        {
            this._appContext = new RepositorioEmpresa(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        public void OnGet()
        {
            empresas =_appContext.GetAllEmpresas(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            empresas = _appContext.GetAllEmpresas(searchString);
            return Page();
        }
    }
}
