using GestionDeMetas.Shared.DTO.Actividad;
using GestionDeMetas.Shared.DTO.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Bussiness.ICore
{
    public interface IActividadCore
    {
        Task<RespuestaDTO> Crear(ActividadDTO actividadDTO);
        Task<RespuestaDTO> Editar(ActividadDTO actividadDTO);
        Task<RespuestaDTO> Eliminar(List<string> ids);
        Task<RespuestaDTO> Destacar(string id);
        Task<RespuestaDTO> Concluir(List<string> ids);
        Task<ActividadDTO> ObtenerActividadPorId(string id);
        Task<List<ActividadDTO>> ObtenerActividadesPorMeta(string idMeta);
    }
}
