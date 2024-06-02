using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Dto;
using simulacro2.Models;
using simulacro2.Services.Medicos;

namespace simulacro2.Controllers.Medicos
{
    
    public class MedicoCrearController : ControllerBase
    {
      
        private readonly IMedicosRepository _MedicosRepository;

        public MedicoCrearController(IMedicosRepository MedicosRepository)
        {
            _MedicosRepository = MedicosRepository;
        }
        [HttpPost]
        [Route("api/Medicos/Crear")]
        public async Task<IActionResult> CrearMedcio([FromBody] MedicoDto medicoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _MedicosRepository.add(medicoDto);
            return Ok(result);
        }
    }
}