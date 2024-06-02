using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simulacro2.Data;
using simulacro2.Models;
using simulacro2.Services.Especialidades;

namespace simulacro2.Controllers.Especialidades
{
    public class EspecialidadesController : ControllerBase
    {

        private readonly IEspecialidadesRepository _especialidadesRepository;

        public EspecialidadesController(IEspecialidadesRepository especialidadesRepository)
        {
            _especialidadesRepository = especialidadesRepository;
        }

        //__________________________________________________//
        [HttpGet]
        [Route("api/especialidades/listar")]
        public IEnumerable<Especialidad> Listar()
        {
            return _especialidadesRepository.GetAll();
        }
        //__________________________________________________//

        [HttpGet]
        [Route("api/especialidades/listarInactivos")]
        public IEnumerable<Especialidad> ListarInactivos()
        {
            return _especialidadesRepository.GetAllInactive();
        }
        //__________________________________________________//

        [HttpGet]
        [Route("api/especialidades/buscar{id}")]
        public Especialidad Obtener(int id)
        {
           return _especialidadesRepository.GetById(id);
            
        }

    }
}