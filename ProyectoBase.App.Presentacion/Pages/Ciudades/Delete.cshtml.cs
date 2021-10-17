using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Ciudades
{
    public class DeleteModel : PageModel
    {
       private readonly IRepositorioCiudad _appContext;

        [BindProperty]
        public Ciudad ciudad  { get; set; } 

        public DeleteModel()
        {
            this._appContext  =new RepositorioCiudad(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Eliminar en la lista
        public IActionResult OnGet(int ciudadId)
        {
            ciudad = _appContext.GetCiudad(ciudadId);
            if(ciudad == null)
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
            if(ciudad.id > 0)
            {
               _appContext.DeleteCiudad(ciudad.id);
            }
            return Page();
        }
    }
}
