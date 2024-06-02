using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simulacro2.Dto;
using simulacro2.Models;

namespace simulacro2.Services.Citas
{
    public interface ICitasRepository
    {
        IEnumerable<Cita> GetAllCita(); 
        IEnumerable<Cita> GetAllInactive(); 
        Task<Cita> GetById(int id); 

        Task <String> DeleteCita(int id,EstadoDto estadoDto);
        Task <String> UptadeCita(int id, CitaDto citaDto);
        Task<string> Add(CitaDto citaDto); 
        Task<int> GetCantidadCitasPorDia(DateTime fecha);
    
    }
}