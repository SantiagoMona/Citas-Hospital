using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Data;
using simulacro2.Models;
using simulacro2.Services.Citas;

namespace simulacro2.Controllers.Citas
{
    public class CitasController : ControllerBase
    {

        private readonly ICitasRepository _citaRepository;

        public CitasController(ICitasRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        //__________________________________________________//
        [HttpGet]
        [Route("api/cita/listar")]
        public IEnumerable<Cita> Listar()
        {
            return _citaRepository.GetAllCita();
        }
        //__________________________________________________//

        [HttpGet]
        [Route("api/cita/listarInactivos")]
        public IEnumerable<Cita> ListarInactivos()
        {
            return _citaRepository.GetAllInactive();
        }
        //__________________________________________________//

        [HttpGet]
        [Route("api/cita/buscar{id}")]
        public async Task<Cita> Obtener(int id)
        {
           return await _citaRepository.GetById(id);
            
        }

    }
}