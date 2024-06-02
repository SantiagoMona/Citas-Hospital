using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using simulacro2.Data;
using simulacro2.Dto;
using simulacro2.Models;



namespace simulacro2.Services.Pacientes
{
    public class PacientesRepository : IPacientesRepository
    {
        private readonly BaseContext _context;
        public PacientesRepository(BaseContext context)
        {
            _context = context;
        }

        /*==================== LISTAR ======================*/

        public IEnumerable<Paciente> GetAllInactive()
        {
            return _context.Pacientes.Where(a => a.Estado == "Inactivo").ToList();
            
        }

        public IEnumerable<Paciente> GetAllPacientes()
        {
           return _context.Pacientes.ToList();
        }

        public Paciente GetById(int id)
        {
            return  _context.Pacientes.Find(id);
        }
        /*=============================== CREAR ======================*/
       public async Task<string> add(PacienteDto pacienteDto)
        {
            bool emailExists = await _context.Pacientes.AnyAsync(p => p.Correo == pacienteDto.Correo);

             string[] generoValido = { "Masculino", "Femenino", "Otro" };
                if (!generoValido.Contains(pacienteDto.Genero))
                {
                    return "El valor de Género no es válido.";
                }

            if (emailExists)
            {
                return "El correo electrónico ya está registrado.";
            }

            var nuevopaciente = new Paciente
            {
                Nombre = pacienteDto.Nombre,
                Apellido = pacienteDto.Apellido,
                FechaNacimiento = pacienteDto.FechaNacimiento,
                Genero = pacienteDto.Genero,
                Direccion = pacienteDto.Direccion,
                Telefono = pacienteDto.Telefono,
                Correo = pacienteDto.Correo,
                Estado = pacienteDto.Estado
            };

            await _context.Pacientes.AddAsync(nuevopaciente);
            await _context.SaveChangesAsync();
            return "Paciente creado exitosamente";
        }
        /*=============================== CAMBIO DE ESTADO ======================*/

        public async Task<string> DeletePac(int id, EstadoDto estadoDto)
        {
            var serchPac = _context.Pacientes.Find(id);

           switch (estadoDto.Estado.ToLower())
            {
                case "activo":
                case "activar":
                    serchPac.Estado = "Activo";
                    _context.Pacientes.Update(serchPac);
                    await _context.SaveChangesAsync();
                    return "El paciente ha sido Activado exitosamente";
                    
                case "inactivo":
                case "inactivar":
                    serchPac.Estado = "Inactivo";
                    _context.Pacientes.Update(serchPac);
                    await _context.SaveChangesAsync();
                    return "El paciente Inactivado exitosamente";

                default:
                    serchPac.Estado = "Inactivo";
                    _context.Pacientes.Update(serchPac);
                    await _context.SaveChangesAsync();
                    return "El paciente ha sido Inactivado exitosamente";
            }
        }
        /*=============================== ACTUALIZAR ======================*/

        public async Task<string> UptadeEsp(int id, PacienteDto pacienteDto)
        {
            bool emailExists = await _context.Pacientes.AnyAsync(p => p.Correo == pacienteDto.Correo);
    
            if (emailExists)
            {
                return "El correo electrónico ya está registrado.";
            }
            var SerchPaciente = _context.Pacientes.Find(id);
           if (SerchPaciente == null)
           {
            return "no ahi nada con este ID";
           }

            SerchPaciente.Nombre = pacienteDto.Nombre;
            SerchPaciente.Estado = pacienteDto.Estado;
            SerchPaciente.Apellido = pacienteDto.Apellido;
            SerchPaciente.FechaNacimiento = pacienteDto.FechaNacimiento;
            SerchPaciente.Genero = pacienteDto.Genero;
            SerchPaciente.Direccion = pacienteDto.Direccion;
            SerchPaciente.Telefono = pacienteDto.Telefono;
            SerchPaciente.Correo = pacienteDto.Correo;
            SerchPaciente.Estado = pacienteDto.Estado;


            _context.Pacientes.Update(SerchPaciente);
            await _context.SaveChangesAsync();
            return "ha sido guardado con exito";
        }

        
    }
}