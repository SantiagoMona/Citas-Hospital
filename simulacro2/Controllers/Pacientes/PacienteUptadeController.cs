using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Dto;
using simulacro2.Services.Pacientes;

namespace simulacro2.Controllers.Pacientes
{
    
    public class PacienteUptadeController : ControllerBase
    {
        private readonly IPacientesRepository _pacientes;
        public PacienteUptadeController(IPacientesRepository pacientesRepository)
        {
            _pacientes = pacientesRepository;
        }
        [HttpPut]
        [Route("api/Pacientes/Actualizar{id}")]
        public async Task<IActionResult> UpdateEspecialidad(int id, [FromBody] PacienteDto pacienteDto)
        {
           
            var result = await _pacientes.UptadeEsp(id, pacienteDto);
            if (result == "Paciente no encontrado")
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}