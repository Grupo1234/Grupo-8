using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProyectoBase.App.Dominio;
using ProyectoBase.App.Persistencia.AppRepositorio;

namespace ProyectoBase.App.Presentacion.Pages.Empleados
{
    public class DeleteModel : PageModel
    {
       private readonly IRepositorioEmpleado _appContext;

        [BindProperty]
        public Empleado empleado  { get; set; } 

        public DeleteModel()
        {
            this._appContext  =new RepositorioEmpleado(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Eliminar en la lista
        public IActionResult OnGet(int empleadoId)
        {
            empleado = _appContext.GetEmpleado(empleadoId);
            if(empleado == null)
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
            if(empleado.id > 0)
            {
               _appContext.DeleteEmpleado(empleado.id);
            }
            return Page();
        }
    }
}
