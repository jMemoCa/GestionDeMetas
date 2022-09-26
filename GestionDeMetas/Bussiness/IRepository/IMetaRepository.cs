using GestionDeMetas.Bussiness.Core;
using GestionDeMetas.Bussiness.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Bussiness.IRepository
{
    public interface IMetaRepository
    {       
        Task<bool> Crear(Meta meta);
        Task<bool> Editar(Meta meta);
        Task<bool> Eliminar(Meta meta);
        Task<List<Meta>> ObtenerMetas();
        Task<bool> ExisteNombreMeta(string nombre);
        Task<Meta> ObtenerMetaPorId(string id); 
    }
}
