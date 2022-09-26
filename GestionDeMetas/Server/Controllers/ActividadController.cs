using GestionDeMetas.Bussiness.Core;
using GestionDeMetas.Bussiness.ICore;
using GestionDeMetas.Shared.DTO.Actividad;
using GestionDeMetas.Shared.DTO.Genericos;
using GestionDeMetas.Shared.DTO.Meta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeMetas.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        public ActividadController(IActividadCore actividadCore)
        {
            ActividadCore = actividadCore;
        }

        public IActividadCore ActividadCore { get; }



        [HttpPost]
        public async Task<ActionResult<RespuestaDTO>> Crear(ActividadDTO actividadDTO)
        {
            return await ActividadCore.Crear(actividadDTO);
        }

        [HttpPut]
        public async Task<ActionResult<RespuestaDTO>> Editar(ActividadDTO actividadDTO)
        {
            return await ActividadCore.Editar(actividadDTO);
        }

        [HttpPost("Eliminar")]
        public async Task<ActionResult<RespuestaDTO>> Delete(List<string> ids)
        {
            return await ActividadCore.Eliminar(ids);
        }

        [HttpPost("Concluir")]
        public async Task<ActionResult<RespuestaDTO>> Concluir(List<string> ids)
        {
            return await ActividadCore.Concluir(ids);
        }

        #region HttpGet


        [HttpGet("ObtenerActividadesPorMeta/{id}")]
        public async Task<ActionResult<List<ActividadDTO>>> ObtenerMetas(string id)
        {
            return await ActividadCore.ObtenerActividadesPorMeta(id);
        }
        [HttpGet("ObtenerActividad/{id}")]
        public async Task<ActionResult<ActividadDTO>> ObtenerMeta(string id)
        {
            return await ActividadCore.ObtenerActividadPorId(id);
        }

        [HttpGet("Destacar/{id}")]
        public async Task<ActionResult<RespuestaDTO>> Destacar(string id)
        {
            return await ActividadCore.Destacar(id);
        }


        #endregion

    }
}
