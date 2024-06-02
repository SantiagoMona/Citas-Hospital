using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simulacro2.Dto
{
    public class MedicoDto
    {
        public string Nombre { get; set; }    
        public string Apellido { get; set; }
        public int Telefono {get; set;}
        public string Correo {get;set;}
        public string Estado {get; set;}
        public int EspecialidadId { get; set; }
    }
}