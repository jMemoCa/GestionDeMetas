using GestionDeMetas.Shared.DTO.Actividad;
using GestionDeMetas.Shared.DTO.Meta;

namespace GestionDeMetas.Client.Services.Interface
{
    public interface IActividad
    {
        Task<List<ActividadDTO>> ObtenerActividadesPorMeta(string idMeta);

        Task<bool> Crear(ActividadDTO actividadDTO);

        Task<bool> Editar(ActividadDTO actividadDTO);

        Task<bool> Eliminar(List<string> ids);
        Task<ActividadDTO> ObtenerActividad(string id);
        Task<bool> Destacar(string id);

        Task<bool> Concluir(List<string> ids); 

    }
}
