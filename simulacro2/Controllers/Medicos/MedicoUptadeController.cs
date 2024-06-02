using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Dto;
using simulacro2.Services.Medicos;

namespace simulacro2.Controllers.Medicos
{
    
    public class MedicoUpdateController : ControllerBase
    {
        private readonly IMedicosRepository _MedicosRepository;

        public MedicoUpdateController(IMedicosRepository MedicosRepository)
        {
            _MedicosRepository = MedicosRepository;
        }

        [HttpPut]
        [Route("api/Medicos/Actualizar{id}")]
        public async Task<IActionResult> UpdateEspecialidad(int id, [FromBody] MedicoDto medicoDto)
        {
           
            var result = await _MedicosRepository.UptadeMed(id, medicoDto);
            if (result == "Medico no encontrado")
            {
                return NotFound(result);
            }

            return Ok(result);
        }


    }
}