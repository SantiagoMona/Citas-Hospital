using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Models;
using simulacro2.Services.Pacientes;

namespace simulacro2.Controllers.Pacientes
{
    
    public class PacientesController : ControllerBase
    {   
        private readonly IPacientesRepository _PacientesRepository;

        public PacientesController(IPacientesRepository PacientesRepository)
        {
            _PacientesRepository = PacientesRepository;
        }
        //__________________________________________________//
        [HttpGet]
        [Route("api/Pacientes/Listar")]
        public IEnumerable<Paciente> Listar()
        {
            return _PacientesRepository.GetAllPacientes();
        }
        //__________________________________________________//
        [HttpGet]
        [Route("api/Pacientes/Buscar{id}")]
        public Paciente Obtener(int id)
        {
            return _PacientesRepository.GetById(id);
        }
        //__________________________________________________//
        [HttpGet]
        [Route("api/Pacientes/ListarInactivos")]
        public IEnumerable<Paciente> ListarInactivos()
        {
            return _PacientesRepository.GetAllInactive();
        }

    }
}