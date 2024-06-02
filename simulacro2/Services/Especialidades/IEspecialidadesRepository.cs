using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simulacro2.Dto;
using simulacro2.Models;

namespace simulacro2.Services.Especialidades
{
    public interface IEspecialidadesRepository
    {
        IEnumerable<Especialidad> GetAll(); 
        IEnumerable<Especialidad> GetAllInactive(); 
        Especialidad GetById(int id); 

        Task <String> Delete(int id,EstadoDto estadoDto);
        Task <String> UptadeEsp(int id, EspecialidadDto especialidadDto);
        Task<string> add(EspecialidadDto especialidadDto); 
    }
}