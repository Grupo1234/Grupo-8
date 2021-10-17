using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Estadosciviles
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioEstadocivil _appContext;
        public Estadocivil estadocivil { get; set; }

        public DetailsModel()
        {
            this._appContext=new RepositorioEstadocivil(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        //se ejecuta al presionar Detalle en la lista
        public IActionResult OnGet(int estadocivilId)
        {
            estadocivil = _appContext.GetEstadocivil(estadocivilId);
            if(estadocivil == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}