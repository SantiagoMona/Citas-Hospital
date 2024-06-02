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
   
    public class EspecialidadesDeleteController : ControllerBase
    {
        private readonly IEspecialidadesRepository _especialidadesRepository;

        public EspecialidadesDeleteController(IEspecialidadesRepository especialidadesRepository)
        {
            _especialidadesRepository = especialidadesRepository;
        }
        [HttpDelete]
        [Route("api/Especialidades/Eliminar{id}")]
        public async Task<IActionResult> DeleteEspecialidad(int id,EstadoDto estadoDto)
        {
            var result = await _especialidadesRepository.Delete(id, estadoDto);
            return Ok(result);
        }
    }
}