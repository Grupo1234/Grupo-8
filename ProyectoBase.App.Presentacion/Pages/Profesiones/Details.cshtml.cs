using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Profesiones
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioProfesion _appContext;
        public Profesion profesion { get; set; }

        public DetailsModel()
        {
            this._appContext=new RepositorioProfesion(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        //se ejecuta al presionar Detalle en la lista
        public IActionResult OnGet(int profesionId)
        {
            profesion = _appContext.GetProfesion(profesionId);
            if(profesion == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}