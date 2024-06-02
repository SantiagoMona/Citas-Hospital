using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simulacro2.Dto;
using simulacro2.Models;

namespace simulacro2.Services.Pacientes
{
    public interface IPacientesRepository
    {
        IEnumerable<Paciente> GetAllPacientes(); 
        IEnumerable<Paciente> GetAllInactive(); 
        Paciente GetById(int id); 

        Task <String> DeletePac(int id,EstadoDto estadoDto);
        Task <String> UptadeEsp(int id, PacienteDto pacienteDto);
        Task<string> add(PacienteDto pacienteDto); 
    
    }
}