using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Dto;
using simulacro2.Models;
using simulacro2.Services.Citas;

namespace simulacro2.Controllers.Citas
{
    
    public class CitaCrearController : ControllerBase
    {
      
        private readonly ICitasRepository _citaRepository;

        public CitaCrearController(ICitasRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }
        [HttpPost]
        [Route("api/Citas/Crear")]
        public async Task<IActionResult> CrearCita([FromBody] CitaDto citaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _citaRepository.Add(citaDto);
            return Ok(result);
        }
    }
}