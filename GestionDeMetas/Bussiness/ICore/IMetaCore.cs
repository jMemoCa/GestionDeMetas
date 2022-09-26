using GestionDeMetas.Shared.DTO.Genericos;
using GestionDeMetas.Shared.DTO.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Bussiness.ICore
{
    public interface IMetaCore
    {
        Task<RespuestaDTO> Crear(MetaDTO metaDTO);
        Task<RespuestaDTO> Editar(MetaDTO metaDTO);
        
        Task<RespuestaDTO> Eliminar(string idMeta);

        Task<bool> ExisteNombreMeta(string nombre);

        Task<List<DetalleMetaDTO>> Obtener();
        Task<MetaDTO> ObtenerMeta(string id);

    }
}
