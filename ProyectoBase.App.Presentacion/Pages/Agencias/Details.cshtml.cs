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
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioAgencia _appContext;
        public Agencia agencia { get; set; }

        public DetailsModel()
        {
            this._appContext=new RepositorioAgencia(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        //se ejecuta al presionar Detalle en la lista
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
    }
}