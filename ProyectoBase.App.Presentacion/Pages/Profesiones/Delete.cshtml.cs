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
    public class DeleteModel : PageModel
    {
       private readonly IRepositorioProfesion _appContext;

        [BindProperty]
        public Profesion profesion  { get; set; } 

        public DeleteModel()
        {
            this._appContext  =new RepositorioProfesion(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Eliminar en la lista
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

        //se ejecuta al presionar Eliminar en el formulario 
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(profesion.id > 0)
            {
               _appContext.DeleteProfesion(profesion.id);
            }
            return Page();
        }
    }
}
