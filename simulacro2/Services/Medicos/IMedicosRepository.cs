using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simulacro2.Dto;
using simulacro2.Models;

namespace simulacro2.Services.Medicos
{
    public interface IMedicosRepository
    {
        IEnumerable<Medico> GetAllMedico(); 
        IEnumerable<Medico> GetAllInactive(); 
        Medico GetById(int id); 

        Task <String> DeleteMed(int id,EstadoDto estadoDto);
        Task <String> UptadeMed(int id, MedicoDto medicoDto);
        Task<string> add(MedicoDto medicoDto); 
    
    }
}