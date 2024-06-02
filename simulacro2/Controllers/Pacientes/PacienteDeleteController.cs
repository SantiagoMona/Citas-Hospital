using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Services.Pacientes;
using simulacro2.Dto;

namespace simulacro2.Controllers.Pacientes
{
    
    public class PacienteDeleteController : Controller
    {
        private readonly IPacientesRepository _pacientes;
        public PacienteDeleteController(IPacientesRepository pacientesRepository)
        {
            _pacientes = pacientesRepository;
        }
        [HttpDelete]
        [Route("api/Pacientes/Eliminar{id}")]
        public async Task<IActionResult> DeleteEspecialidad(int id,EstadoDto estadoDto)
        {
            var result = await _pacientes.DeletePac(id, estadoDto);
            return Ok(result);
        }
    }
}