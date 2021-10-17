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
    public class DeleteModel : PageModel
    {
       private readonly IRepositorioEstadocivil _appContext;

        [BindProperty]
        public Estadocivil estadocivil  { get; set; } 

        public DeleteModel()
        {
            this._appContext  =new RepositorioEstadocivil(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Eliminar en la lista
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

        //se ejecuta al presionar Eliminar en el formulario 
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(estadocivil.id > 0)
            {
               _appContext.DeleteEstadocivil(estadocivil.id);
            }
            return Page();
        }
    }
}