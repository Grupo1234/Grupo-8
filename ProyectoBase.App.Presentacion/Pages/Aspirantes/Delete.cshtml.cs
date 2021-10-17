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
    public class DeleteModel : PageModel
    {
       private readonly IRepositorioAspirante _appContext;

        [BindProperty]
        public Aspirante aspirante  { get; set; } 

        public DeleteModel()
        {
            this._appContext  =new RepositorioAspirante(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Eliminar en la lista
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

        //se ejecuta al presionar Eliminar en el formulario 
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(aspirante.id > 0)
            {
               _appContext.DeleteAspirante(aspirante.id);
            }
            return Page();
        }
    }
}


