using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Profesiones
{
    public class EditModel : PageModel
    {
       private readonly IRepositorioProfesion _appContext;

        [BindProperty]
        public Profesion profesion  { get; set; } 

        public EditModel()
        {
            this._appContext  =new RepositorioProfesion(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? profesionId)
        {
            if (profesionId.HasValue)
            {
                profesion = _appContext.GetProfesion(profesionId.Value);
            }
            else
            {
                profesion = new Profesion();
            }

            if (profesion == null)
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
            if(profesion.id > 0)
            {
               profesion = _appContext.UpdateProfesion( profesion );               
            }
            else
            {
               _appContext.AddProfesion( profesion );
            }
            return Page();
        }
    }
}
