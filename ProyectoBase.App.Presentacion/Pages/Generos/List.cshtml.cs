using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoBase.App.Dominio;

using ProyectoBase.App.Persistencia.AppRepositorio;
using ProyectoBase.App.Persistencia;

namespace ProyectoBase.App.Presentacion.Pages.Generos
{
    //[Authorize]
    public class ListModel : PageModel
    {
        private readonly IRepositorioGenero _appContext;
        public IEnumerable<Genero> generos {get; set;} 

        public string searchString;     

        public ListModel()
        {
            this._appContext = new RepositorioGenero(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        public void OnGet()
        {
            generos =_appContext.GetAllGeneros(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            generos = _appContext.GetAllGeneros(searchString);
            return Page();
        }
    }
}
