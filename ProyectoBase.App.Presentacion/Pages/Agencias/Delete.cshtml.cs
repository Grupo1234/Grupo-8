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
    public class DeleteModel : PageModel
    {
       private readonly IRepositorioAgencia _appContext;

        [BindProperty]
        public Agencia agencia  { get; set; } 

        public DeleteModel()
        {
            this._appContext  =new RepositorioAgencia(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Eliminar en la lista
        public IActionResult OnGet(int agenciaId)
        {
            agencia = _appContext.GetAgencia(agenciaId);
            if(agencia == null)
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
            if(agencia.id > 0)
            {
               _appContext.DeleteAgencia(agencia.id);
            }
            return Page();
        }
    }
}
