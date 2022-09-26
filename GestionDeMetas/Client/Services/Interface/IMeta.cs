using GestionDeMetas.Shared.DTO.Genericos;
using GestionDeMetas.Shared.DTO.Meta;

namespace GestionDeMetas.Client.Services.Interface
{
    public interface IMeta
    {
        Task<List<DetalleMetaDTO>> ObtenerMetas(); 

        Task<bool> Crear(MetaDTO metaDTO);

        Task<bool> Editar(MetaDTO metaDTO);

        Task<bool> Eliminar(string metaId);
        Task<MetaDTO> ObtenerMeta(string id);

    }
}
