using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Dto;
using simulacro2.Models;
using simulacro2.Services.Especialidades;

namespace simulacro2.Controllers.Especialidades
{
    
    public class EspecialidadCrearController : ControllerBase
    {
      
        private readonly IEspecialidadesRepository _especialidadesRepository;

        public EspecialidadCrearController(IEspecialidadesRepository especialidadesRepository)
        {
            _especialidadesRepository = especialidadesRepository;
        }
        [HttpPost]
        [Route("api/Especialidades/Crear")]
        public async Task<IActionResult> CrearEspecialidad([FromBody] EspecialidadDto especialidadDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _especialidadesRepository.add(especialidadDto);
            return Ok(result);
        }
    }
}