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
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioEmpresa _appContext;
        public Empresa empresa { get; set; }

        public DetailsModel()
        {
            this._appContext=new RepositorioEmpresa(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        //se ejecuta al presionar Detalle en la lista
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
    }
}
