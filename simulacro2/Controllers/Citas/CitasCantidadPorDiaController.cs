using Microsoft.AspNetCore.Mvc;
using simulacro2.Services.Citas;

namespace simulacro2.Controllers.Citas
{
    
    public class CitasCantidadPorDiaController : ControllerBase
    {
       private readonly ICitasRepository _citaRepository;

        public CitasCantidadPorDiaController(ICitasRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }
        [HttpGet]
        [Route("api/Cita/CantidadPorDia")]
        public async Task<IActionResult> ListarPorDia(DateTime fecha)
        {
            int cantidad = await _citaRepository.GetCantidadCitasPorDia(fecha);
            return Ok(new { Fecha = fecha, Cantidad = cantidad });
        }
        
    }
}