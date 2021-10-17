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
    public class EditModel : PageModel
    {
       private readonly IRepositorioEstadocivil _appContext;

        [BindProperty]
        public Estadocivil estadocivil  { get; set; } 

        public EditModel()
        {
            this._appContext  =new RepositorioEstadocivil(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? estadocivilId)
        {
            if (estadocivilId.HasValue)
            {
                estadocivil = _appContext.GetEstadocivil(estadocivilId.Value);
            }
            else
            {
                estadocivil = new Estadocivil();
            }

            if (estadocivil == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }

        //se ejecuta al presionar Editar en el formulario
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(estadocivil.id > 0)
            {
               estadocivil = _appContext.UpdateEstadocivil( estadocivil );               
            }
            else
            {
               _appContext.AddEstadocivil( estadocivil );
            }
            return Page();
        }
    }
}

