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
    public class EditModel : PageModel
    {
       private readonly IRepositorioAspirante _appContext;

        [BindProperty]
        public Aspirante aspirante  { get; set; } 

        public EditModel()
        {
            this._appContext  =new RepositorioAspirante(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? aspiranteId)
        {
            if (aspiranteId.HasValue)
            {
                aspirante = _appContext.GetAspirante(aspiranteId.Value);
            }
            else
            {
                aspirante = new Aspirante();
            }

            if (aspirante == null)
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
            if(aspirante.id > 0)
            {
               aspirante = _appContext.UpdateAspirante( aspirante );               
            }
            else
            {
               _appContext.AddAspirante( aspirante );
            }
            return Page();
        }
    }
}


