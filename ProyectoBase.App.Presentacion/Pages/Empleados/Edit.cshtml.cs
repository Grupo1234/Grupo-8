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
    public class EditModel : PageModel
    {
       private readonly IRepositorioEmpleado _appContext;

        [BindProperty]
        public Empleado empleado  { get; set; } 

        public EditModel()
        {
            this._appContext  =new RepositorioEmpleado(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }
     

        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? empleadoId)
        {
            if (empleadoId.HasValue)
            {
                empleado = _appContext.GetEmpleado(empleadoId.Value);
            }
            else
            {
                empleado = new Empleado();
            }

            if (empleado == null)
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
            if(empleado.id > 0)
            {
               empleado = _appContext.UpdateEmpleado( empleado );               
            }
            else
            {
               _appContext.AddEmpleado( empleado );
            }
            return Page();
        }
    }
}

