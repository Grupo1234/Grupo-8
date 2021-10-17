using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Ciudades
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioCiudad _appContext;
        public Ciudad ciudad { get; set; }

        public DetailsModel()
        {
            this._appContext=new RepositorioCiudad(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        //se ejecuta al presionar Detalle en la lista
        public IActionResult OnGet(int ciudadId)
        {
            ciudad = _appContext.GetCiudad(ciudadId);
            if(ciudad == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}