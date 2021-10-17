using System;
namespace ProyectoBase.App.Dominio
{
    public class Empresas_vacantes
    {
        public string fechainicio {get; set; }   
        public string fechafin { get; set; }
        public int empresa { get; set; } 
        public int vacantes { get; set; }
        public int empleado_aspirante { get; set; }
    }
}