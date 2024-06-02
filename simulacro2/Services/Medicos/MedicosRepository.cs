using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using simulacro2.Data;
using simulacro2.Dto;
using simulacro2.Models;



namespace simulacro2.Services.Medicos
{
    public class MedicosRepository : IMedicosRepository
    {
        private readonly BaseContext _context;
        public MedicosRepository (BaseContext baseContext)
        {
            _context = baseContext;
        }

        /*==================== LISTAR ======================*/

        public IEnumerable<Medico> GetAllInactive()
        {
            return _context.Medicos.Where(a => a.Estado == "Inactivo")
            .Include(e => e.Especialidad).ToList();
            
        }

        public IEnumerable<Medico> GetAllMedico()
        {
           return _context.Medicos.Include(e => e.Especialidad).ToList();
        }

        public Medico GetById(int id)
        {
            return  _context.Medicos.Find(id);
        }
        /*=============================== CREAR ======================*/
       public async Task<string> add(MedicoDto medicoDto)
        {
            bool emailExists = await _context.Medicos.AnyAsync(p => p.Correo == medicoDto.Correo);

            if (emailExists)
            {
                return "El correo electrónico ya está registrado.";
            }

            var nuevoMedico = new Medico
            {
                Nombre = medicoDto.Nombre,
                Apellido = medicoDto.Apellido,
                Telefono = medicoDto.Telefono,
                Correo = medicoDto.Correo,
                Estado = medicoDto.Estado,
                EspecialidadId = medicoDto.EspecialidadId
            };

            await _context.Medicos.AddAsync(nuevoMedico);
            await _context.SaveChangesAsync();
            return "Medico creado exitosamente";
        }
        /*=============================== CAMBIO DE ESTADO ======================*/

        public async Task<string>DeleteMed(int id, EstadoDto estadoDto)
        {
            var serchPac = _context.Medicos.Find(id);

           switch (estadoDto.Estado.ToLower())
            {
                case "activo":
                case "activar":
                    serchPac.Estado = "Activo";
                    _context.Medicos.Update(serchPac);
                    await _context.SaveChangesAsync();
                    return "El MEdico ha sido Activado exitosamente";
                    
                case "inactivo":
                case "inactivar":
                    serchPac.Estado = "Inactivo";
                    _context.Medicos.Update(serchPac);
                    await _context.SaveChangesAsync();
                    return "El MEdico Se Inactivo exitosamente";

                default:
                    serchPac.Estado = "Inactivo";
                    _context.Medicos.Update(serchPac);
                    await _context.SaveChangesAsync();
                    return "El MEdico ha sido Inactivado exitosamente";
            }
        }
        /*=============================== ACTUALIZAR ======================*/

        public async Task<string> UptadeMed(int id, MedicoDto medicoDto)
        {
            bool emailExists = await _context.Medicos.AnyAsync(p => p.Correo == medicoDto.Correo);
    
            if (emailExists)
            {
                return "El correo electrónico ya está registrado.";
            }
            var SerchMedico = _context.Medicos.Find(id);
           if (SerchMedico == null)
           {
            return "no ahi nada con este ID";
           }

            SerchMedico.Nombre = medicoDto.Nombre;
            SerchMedico.Estado = medicoDto.Estado;
            SerchMedico.Apellido = medicoDto.Apellido;
            SerchMedico.EspecialidadId = medicoDto.EspecialidadId;
            SerchMedico.Telefono = medicoDto.Telefono;
            SerchMedico.Correo = medicoDto.Correo;
            SerchMedico.Estado = medicoDto.Estado;


            _context.Medicos.Update(SerchMedico);
            await _context.SaveChangesAsync();
            return "ha sido guardado con exito";
        }

    }
}