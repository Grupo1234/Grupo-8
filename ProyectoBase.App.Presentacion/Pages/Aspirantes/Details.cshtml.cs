using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Aspirantes
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioAspirante _appContext;
        public Aspirante aspirante { get; set; }

        public DetailsModel()
        {
            this._appContext=new RepositorioAspirante(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        //se ejecuta al presionar Detalle en la lista
        public IActionResult OnGet(int aspiranteId)
        {
            aspirante = _appContext.GetAspirante(aspiranteId);
            if(aspirante == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}

