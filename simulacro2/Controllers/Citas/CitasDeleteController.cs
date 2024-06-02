using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Dto;
using simulacro2.Services.Citas;

namespace simulacro2.Controllers.Citas
{
   
    public class CitasDeleteController : ControllerBase
    {
        private readonly ICitasRepository _citaRepository;

        public CitasDeleteController(ICitasRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }
        [HttpDelete]
        [Route("api/Citas/Eliminar{id}")]
        public async Task<IActionResult> deletecita(int id,EstadoDto estadoDto)
        {
            var result = await _citaRepository.DeleteCita(id, estadoDto);
            return Ok(result);
        }
    }
}