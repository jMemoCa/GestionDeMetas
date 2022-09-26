using GestionDeMetas.Bussiness.IRepository;
using GestionDeMetas.Bussiness.Persistence;
using GestionDeMetas.Bussiness.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Bussiness.Repository
{
    public class ActividadRepository : IActividadRepository
    {
        public ActividadRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }


        public async Task<bool> Concluir(string id)
        {
            try
            {
                Actividad actividad = new Actividad { Id = id, Concluida = true };
                ApplicationDbContext.Actividad.Attach(actividad);

                ApplicationDbContext.Entry(actividad).Property(x => x.Concluida).IsModified = true;
                await ApplicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Crear(Actividad actividad)
        {
            try
            {
                ApplicationDbContext.Add(actividad);
                await ApplicationDbContext.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Destacar(string id)
        {
            try
            {
                Actividad actividad =await ApplicationDbContext.Actividad.SingleOrDefaultAsync(x=>x.Id==id);

                actividad.Importante = !actividad.Importante;
                ApplicationDbContext.Actividad.Attach(actividad);

                ApplicationDbContext.Entry(actividad).Property(x => x.Importante).IsModified = true;
               await  ApplicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public async Task<bool> Editar(Actividad actividad)
        {
            try
            {
                ApplicationDbContext.Attach(actividad).State = EntityState.Modified;
                await ApplicationDbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(List<string> ids)
        {
            try
            {
                var eliminar = ApplicationDbContext.Actividad.Where(x => ids.Contains(x.Id));

                ApplicationDbContext.RemoveRange(eliminar);
                await ApplicationDbContext.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            } 
        }

        public async Task<List<Actividad>> ObtenerActividadesPorMeta(string idMeta)
        {

            try
            {
                return await ApplicationDbContext.Actividad.Where(x => x.MetaId == idMeta).ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Actividad>();
            }
        }

        public async Task<Actividad> ObtenerActividadPorId(string id)
        {
            try
            {
                return await ApplicationDbContext.Actividad.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
