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
    
    public class CitaUpdateController : ControllerBase
    {
        private readonly ICitasRepository _citaRepository;

        public CitaUpdateController(ICitasRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPut]
        [Route("api/Citas/Actualizar{id}")]
        public async Task<IActionResult> UpdateCita(int id, [FromBody] CitaDto citaDto)
        {
           
            var result = await _citaRepository.UptadeCita(id, citaDto);
            if (result == "Cita no encontrada")
            {
                return NotFound(result);
            }

            return Ok(result);
        }


    }
}