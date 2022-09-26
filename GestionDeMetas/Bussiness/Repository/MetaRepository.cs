using GestionDeMetas.Bussiness.Persistence.Models;
using GestionDeMetas.Bussiness.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDeMetas.Bussiness.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GestionDeMetas.Bussiness.Repository
{
    public class MetaRepository : IMetaRepository
    {

        public MetaRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationDbContext ApplicationDbContext { get; }

        public async Task<bool> Crear(Meta meta)
        {
            try
            {
                ApplicationDbContext.Add(meta);
                await ApplicationDbContext.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Editar(Meta meta)
        {
            try
            {
                ApplicationDbContext.Attach(meta).State = EntityState.Modified;
                await ApplicationDbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Eliminar(Meta meta)
        {
            try
            {
                ApplicationDbContext.Remove(meta);
                await ApplicationDbContext.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ExisteNombreMeta(string nombre)
        {
            try
            {
                var contadorMismoNombre= await ApplicationDbContext.Meta.Where(x => x.Nombre.ToLower() == nombre.ToLower()).CountAsync();

                return contadorMismoNombre > 0;
            }
            catch (Exception)
            {

                return true;
            }

        }

        public async Task<Meta> ObtenerMetaPorId(string id)
        {
            try
            {
                return await ApplicationDbContext.Meta.SingleOrDefaultAsync(x=>x.Id==id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Meta>> ObtenerMetas()
        {
            try
            {
                return await ApplicationDbContext.Meta.Include("Actividades").ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Meta>();
            }
        }
    }
}
