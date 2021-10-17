using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Agencias
{
    public class EditModel : PageModel
    {
       private readonly IRepositorioAgencia _appContext;

        [BindProperty]
        public Agencia agencia  { get; set; } 

        public EditModel()
        {
            this._appContext  =new RepositorioAgencia(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? agenciaId)
        {
            if (agenciaId.HasValue)
            {
                agencia = _appContext.GetAgencia(agenciaId.Value);
            }
            else
            {
                agencia = new Agencia();
            }

            if (agencia == null)
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
            if(agencia.id > 0)
            {
               agencia = _appContext.UpdateAgencia( agencia );               
            }
            else
            {
               _appContext.AddAgencia( agencia );
            }
            return Page();
        }
    }
}
