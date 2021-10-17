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
    public class EditModel : PageModel
    {
       private readonly IRepositorioCiudad _appContext;

        [BindProperty]
        public Ciudad ciudad  { get; set; } 

        public EditModel()
        {
            this._appContext  =new RepositorioCiudad(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? ciudadId)
        {
            if (ciudadId.HasValue)
            {
                ciudad = _appContext.GetCiudad(ciudadId.Value);
            }
            else
            {
                ciudad = new Ciudad();
            }

            if (ciudad == null)
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
            if(ciudad.id > 0)
            {
               ciudad = _appContext.UpdateCiudad( ciudad );               
            }
            else
            {
               _appContext.AddCiudad( ciudad );
            }
            return Page();
        }
    }
}

