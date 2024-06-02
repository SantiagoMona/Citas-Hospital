using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace simulacro2.Models
{
    public class Cita
    {
    
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Motivo { get; set; }
    public string Estado {get;set;}



    [ForeignKey("Paciente")]
    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    [ForeignKey("Medico")]
    public int MedicoId { get; set; }
    public Medico? Medico { get; set; }
    }
}