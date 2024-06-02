using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Dto;
using simulacro2.Services.Especialidades;
using simulacro2.Services.Pacientes;


namespace simulacro2.Controllers.Pacientes
{
    public class PacienteCreateController : ControllerBase
    {
        private readonly IPacientesRepository _pacientes;
        public PacienteCreateController(IPacientesRepository pacientesRepository)
        {
            _pacientes = pacientesRepository;
        }
        [HttpPost]
        [Route("api/Pacientes/Crear")]
         public async Task<IActionResult> CrearPaciente([FromBody] PacienteDto pacienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _pacientes.add(pacienteDto);
            return Ok(result);
        }
    }
}