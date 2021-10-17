using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Generos
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioGenero _appContext;
        public Genero genero { get; set; }

        public DetailsModel()
        {
            this._appContext=new RepositorioGenero(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        //se ejecuta al presionar Detalle en la lista
        public IActionResult OnGet(int generoId)
        {
            genero = _appContext.GetGenero(generoId);
            if(genero == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}