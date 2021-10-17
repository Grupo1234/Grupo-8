using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Generos
{
    public class DeleteModel : PageModel
    {
       private readonly IRepositorioGenero _appContext;

        [BindProperty]
        public Genero genero  { get; set; } 

        public DeleteModel()
        {
            this._appContext  =new RepositorioGenero(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Eliminar en la lista
        public IActionResult OnGet(int generoId)
        {
            genero = _appContext.GetGenero(generoId);
            if(genero == null)
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
            if(genero.id > 0)
            {
               _appContext.DeleteGenero(genero.id);
            }
            return Page();
        }
    }
}