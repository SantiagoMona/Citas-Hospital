using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using simulacro2.Models;

namespace simulacro2.Models
{
    public class Medico
    {
    public int Id { get; set; }
    public string Nombre { get; set; }    
    public string Apellido { get; set; }
    public int Telefono {get; set;}
    public string Correo {get;set;}
    public string Estado {get; set;}

    public int EspecialidadId { get; set; }
    public Especialidad? Especialidad { get; set; }
    }
}