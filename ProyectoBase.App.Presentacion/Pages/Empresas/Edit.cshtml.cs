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
    public class EditModel : PageModel
    {
       private readonly IRepositorioEmpresa _appContext;

        [BindProperty]
        public Empresa empresa  { get; set; } 

        public EditModel()
        {
            this._appContext  =new RepositorioEmpresa(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? empresaId)
        {
            if (empresaId.HasValue)
            {
                empresa = _appContext.GetEmpresa(empresaId.Value);
            }
            else
            {
                empresa = new Empresa();
            }

            if (empresa == null)
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
            if(empresa.id > 0)
            {
               empresa = _appContext.UpdateEmpresa( empresa );               
            }
            else
            {
               _appContext.AddEmpresa( empresa );
            }
            return Page();
        }
    }
}

