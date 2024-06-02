using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Data;
using simulacro2.Models;
using simulacro2.Services.Medicos;

namespace simulacro2.Controllers.Medicos
{
    public class MedicoController : ControllerBase
    {

        private readonly IMedicosRepository _MedicosRepository;

        public MedicoController(IMedicosRepository medicosRepository)
        {
            _MedicosRepository = medicosRepository;
        }

        //__________________________________________________//
        [HttpGet]
        [Route("api/Medicos/listar")]
        public IEnumerable<Medico> Listar()
        {
            return _MedicosRepository.GetAllMedico();
        }
        //__________________________________________________//

        [HttpGet]
        [Route("api/Medicos/listarInactivos")]
        public IEnumerable<Medico> ListarInactivos()
        {
            return _MedicosRepository.GetAllInactive();
        }
        //__________________________________________________//

        [HttpGet]
        [Route("api/Medicos/buscar{id}")]
        public Medico Obtener(int id)
        {
           return _MedicosRepository.GetById(id);
            
        }

    }
}