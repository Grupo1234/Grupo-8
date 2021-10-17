using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoBase.App.Dominio;

using ProyectoBase.App.Persistencia.AppRepositorio;
using ProyectoBase.App.Persistencia;

namespace ProyectoBase.App.Presentacion.Pages.Profesiones
{
    //[Authorize]
    public class ListModel : PageModel
    {
        private readonly IRepositorioProfesion _appContext;
        public IEnumerable<Profesion> profesiones {get; set;} 

        public string searchString;     

        public ListModel()
        {
            this._appContext = new RepositorioProfesion(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        public void OnGet()
        {
            profesiones =_appContext.GetAllProfesiones(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            profesiones = _appContext.GetAllProfesiones(searchString);
            return Page();
        }
    }
}

