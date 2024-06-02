using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using simulacro2.Data;
using simulacro2.Dto;
using simulacro2.Models;



namespace simulacro2.Services.Citas
{
    public class CitasRepository : ICitasRepository
    {
        private readonly BaseContext _context;
        public CitasRepository (BaseContext baseContext)
        {
            _context = baseContext;
        }

        /*==================== LISTAR ======================*/

        public IEnumerable<Cita> GetAllInactive()
        {
            return _context.Citas.Where(a => a.Estado == "Cancelada")
            .Include(e => e.Paciente).Include(e => e.Medico).ToList();
            
        }

        public IEnumerable<Cita> GetAllCita()
        {
           return _context.Citas.Include(e => e.Paciente).Include(e => e.Medico).ToList();
        }

        public Task<Cita> GetById(int id)
        {
            return _context.Citas.Include(c => c.Paciente).Include(c => c.Medico).FirstOrDefaultAsync(c => c.Id == id);        }
        /*=============================== CREAR ======================*/
       public async Task<string> Add(CitaDto citaDto)
        {

            var nuevaCita = new Cita
            {
                Fecha = citaDto.Fecha,
                Motivo = citaDto.Motivo,
                Estado = "Programada",
                
                MedicoId = citaDto.MedicoId,
                PacienteId = citaDto.PacienteId
            };

            await _context.Citas.AddAsync(nuevaCita);
            await _context.SaveChangesAsync();
            return "Cita creado exitosamente";
        }
        /*=============================== CAMBIO DE ESTADO ======================*/

        public async Task<string>DeleteCita(int id, EstadoDto estadoDto)
        {
            var serchPac = _context.Citas.Find(id);

           switch (estadoDto.Estado.ToLower())
            {
                case "Programada":
                    serchPac.Estado = "Programada";
                    _context.Citas.Update(serchPac);
                    await _context.SaveChangesAsync();
                    return "Su Cita a Sido Programada exitosamente";
                    
                case "cancelada":
                    serchPac.Estado = "Cancelada";
                    _context.Citas.Update(serchPac);
                    await _context.SaveChangesAsync();
                    return "Su Cita a Sido Cancelada exitosamente";

                default:
                    serchPac.Estado = "Cancelada";
                    _context.Citas.Update(serchPac);
                    await _context.SaveChangesAsync();
                    return "Su Cita a Sido Cancelada exitosamente";
            }
        }
        /*=============================== ACTUALIZAR ======================*/

        public async Task<string> UptadeCita(int id, CitaDto citaDto)
        {
    
            var SerchMedico = _context.Citas.Find(id);
           if (SerchMedico == null)
           {
            return "no ahi nada con este ID";
           }

            SerchMedico.Fecha = citaDto.Fecha;
            SerchMedico.Motivo = citaDto.Motivo;
            SerchMedico.Estado = "Programada";
                
            SerchMedico.MedicoId = citaDto.MedicoId;
            SerchMedico.PacienteId = citaDto.PacienteId;

            

            _context.Citas.Update(SerchMedico);
            await _context.SaveChangesAsync();
            return "ha sido guardado con exito";
        }
        /*=============================== CANTIDAD DE CITAS POR DIA  ======================*/

        public async Task<int> GetCantidadCitasPorDia(DateTime fecha)
        {
            return await _context.Citas.Where(c => c.Fecha.Date == fecha.Date).CountAsync();
        }

    }
}