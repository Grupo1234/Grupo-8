using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoBase.App.Dominio;

using ProyectoBase.App.Persistencia.AppRepositorio;
using ProyectoBase.App.Persistencia;

namespace ProyectoBase.App.Presentacion.Pages.Empleados
{
    //[Authorize]
    public class ListModel : PageModel
    {
        private readonly IRepositorioEmpleado _appContext;
        public IEnumerable<Empleado> empleados {get; set;} 

        public string searchString;     

        public ListModel()
        {
            this._appContext = new RepositorioEmpleado(new ProyectoBase.App.Persistencia.AppRepositorio.AppContext());
        }

        public void OnGet()
        {
            empleados =_appContext.GetAllEmpleados(searchString); 
        }

        public IActionResult OnPost(string? searchString)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            empleados = _appContext.GetAllEmpleados(searchString);
            return Page();
        }
    }
}