using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Empresas
{
    public class DeleteModel : PageModel
    {
       private readonly IRepositorioEmpresa _appContext;

        [BindProperty]
        public Empresa empresa  { get; set; } 

        public DeleteModel()
        {
            this._appContext  =new RepositorioEmpresa(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Eliminar en la lista
        public IActionResult OnGet(int empresaId)
        {
            empresa = _appContext.GetEmpresa(empresaId);
            if(empresa == null)
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
            if(empresa.id > 0)
            {
               _appContext.DeleteEmpresa(empresa.id);
            }
            return Page();
        }
    }
}

