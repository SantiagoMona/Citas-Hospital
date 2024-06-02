using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Dto;
using simulacro2.Services;
using simulacro2.Services.Medicos;

namespace simulacro2.Controllers.Medicos
{
   
    public class MedicosDeleteController : ControllerBase
    {
        private readonly IMedicosRepository _MedicosRepository;

        public MedicosDeleteController(IMedicosRepository MedicosRepository)
        {
            _MedicosRepository = MedicosRepository;
        }
        [HttpDelete]
        [Route("api/Medicos/Eliminar{id}")]
        public async Task<IActionResult> Delete(int id,EstadoDto estadoDto)
        {
            var result = await _MedicosRepository.DeleteMed(id, estadoDto);
            return Ok(result);
        }
    }
}