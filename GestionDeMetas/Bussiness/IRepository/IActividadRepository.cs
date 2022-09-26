using GestionDeMetas.Bussiness.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Bussiness.IRepository
{
    public interface IActividadRepository
    {
        Task<bool> Crear(Actividad actividad);
        Task<bool> Editar(Actividad actividad);
        Task<bool> Eliminar(List<string>ids);
        Task<bool> Destacar(string id);
        Task<bool> Concluir(string id);
        Task<Actividad> ObtenerActividadPorId(string id);
        Task<List<Actividad>> ObtenerActividadesPorMeta(string idMeta);
    }
}
