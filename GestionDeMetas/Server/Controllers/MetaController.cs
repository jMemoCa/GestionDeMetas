using GestionDeMetas.Bussiness.ICore;
using GestionDeMetas.Shared.DTO.Genericos;
using GestionDeMetas.Shared.DTO.Meta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeMetas.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MetaController : ControllerBase
    {

        public MetaController(IMetaCore metaCore)
        {
            MetaCore = metaCore;
        }

        public IMetaCore MetaCore { get; }



        [HttpPost]
        public async Task<ActionResult<RespuestaDTO>> Crear(MetaDTO metaDTO)
        {
            return await MetaCore.Crear(metaDTO);
        }

        [HttpPut]
        public async Task<ActionResult<RespuestaDTO>> Editar(MetaDTO metaDTO)
        {
            return await MetaCore.Editar(metaDTO);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<RespuestaDTO>> Delete(string id)
        {
            return await MetaCore.Eliminar(id);
        }


        #region HttpGet
        [HttpGet("ExisteNombreMeta/{nombre}")]
        public async Task<ActionResult<bool>> ExisteNombreMeta(string nombre)
        {
            return await MetaCore.ExisteNombreMeta(nombre);
        }

        [HttpGet("ObtenerMetas")]
        public async Task<ActionResult<List<DetalleMetaDTO>>> ObtenerMetas()
        {
            return await MetaCore.Obtener();
        }
        [HttpGet("ObtenerMeta/{id}")]
        public async Task<ActionResult<MetaDTO>> ObtenerMeta(string id)
        {
            return await MetaCore.ObtenerMeta(id);
        }
        #endregion

    }
}
