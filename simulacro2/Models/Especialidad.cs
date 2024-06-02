using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using simulacro2.Models;

namespace simulacro2.Models
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }

        [JsonIgnore]
        public List<Medico> Medicos { get; set; } 
    }
}