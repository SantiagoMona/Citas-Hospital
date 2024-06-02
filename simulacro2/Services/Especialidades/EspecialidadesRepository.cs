using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using simulacro2.Data;
using simulacro2.Dto;
using simulacro2.Models;

namespace simulacro2.Services.Especialidades
{
    public class EspecialidadesRepository : IEspecialidadesRepository
    {
        private readonly BaseContext _context;
        public EspecialidadesRepository(BaseContext context)
        {
            _context = context;
        }

        /*==================== LISTAR ======================*/

        public IEnumerable<Especialidad> GetAll()
        {
            return _context.Especialidades.ToList();

        }

        public IEnumerable<Especialidad> GetAllInactive()
        {
            return _context.Especialidades.Where(a => a.Estado == "Inactivo").ToList();
        }

        public Especialidad GetById(int id)
        {
            return _context.Especialidades.Find(id);
        }
        /*=============================== ACTUALIZAR ======================*/

        public async Task<string> UptadeEsp(int id, EspecialidadDto especialidadDto)
        {
            
           var SerchEspecialidad = _context.Especialidades.Find(id);
           if (SerchEspecialidad == null)
           {
            return "no ahi nada con este ID";
           }

            SerchEspecialidad.Nombre = especialidadDto.Nombre;
            SerchEspecialidad.Estado = especialidadDto.Estado;
            SerchEspecialidad.Descripcion = especialidadDto.Descripcion;

            _context.Especialidades.Update(SerchEspecialidad);
            await _context.SaveChangesAsync();
            return "ha sido guardado con exito";
        }

        /*=============================== DELETE ======================*/
        public async Task<string> Delete(int id, EstadoDto estadoDto)
        {
            var SerchEsp = _context.Especialidades.Find(id);

           switch (estadoDto.Estado.ToLower())
            {
                case "activo":
                case "activar":
                    SerchEsp.Estado = "Activo";
                    _context.Especialidades.Update(SerchEsp);
                    await _context.SaveChangesAsync();
                    return "Especialidad ha sido Activada exitosamente";
                    
                case "inactivo":
                case "inactivar":
                    SerchEsp.Estado = "Inactivo";
                    _context.Especialidades.Update(SerchEsp);
                    await _context.SaveChangesAsync();
                    return "Especialidad Inactivada exitosamente";

                default:
                    SerchEsp.Estado = "Inactivo";
                    _context.Especialidades.Update(SerchEsp);
                    await _context.SaveChangesAsync();
                    return "Especialidad ha sido Inactivada exitosamente";
            }
        }

        /*=============================== CREAR ======================*/
        public async Task<string> add(EspecialidadDto especialidadDto)
        {
            
            var nuevaEspecialidad = new Especialidad
            {
                Nombre = especialidadDto.Nombre,
                Estado = especialidadDto.Estado,
                Descripcion = especialidadDto.Descripcion
            };

            await _context.Especialidades.AddAsync(nuevaEspecialidad);
            await _context.SaveChangesAsync();
            return "Especialidad creada exitosamente";
        }
        
    }
}