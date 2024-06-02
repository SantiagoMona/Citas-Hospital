using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Dto;
using simulacro2.Services.Especialidades;

namespace simulacro2.Controllers.Especialidades
{
    
    public class EspecialidadUpdateController : ControllerBase
    {
        private readonly IEspecialidadesRepository _especialidadesRepository;

        public EspecialidadUpdateController(IEspecialidadesRepository especialidadesRepository)
        {
            _especialidadesRepository = especialidadesRepository;
        }

        [HttpPut]
        [Route("api/Especialidades/Actualizar{id}")]
        public async Task<IActionResult> UpdateEspecialidad(int id, [FromBody] EspecialidadDto especialidadDto)
        {
           
            var result = await _especialidadesRepository.UptadeEsp(id, especialidadDto);
            if (result == "Especialidad no encontrada")
            {
                return NotFound(result);
            }

            return Ok(result);
        }


    }
}