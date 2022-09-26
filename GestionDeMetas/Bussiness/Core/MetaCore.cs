using FluentValidation.Results;
using GestionDeMetas.Bussiness.ICore;
using GestionDeMetas.Bussiness.IRepository;
using GestionDeMetas.Bussiness.Persistence;
using GestionDeMetas.Bussiness.Persistence.Models;
using GestionDeMetas.Shared.DTO.Genericos;
using GestionDeMetas.Shared.DTO.Meta;
using GestionDeMetas.Shared.Validations;
using Mapster;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Bussiness.Core
{
    public class MetaCore : IMetaCore
    {

        public MetaCore(IMetaRepository metaRepository)
        {
            MetaRepository = metaRepository;
        }

        public IMetaRepository MetaRepository { get; }

        public async Task<RespuestaDTO> Crear(MetaDTO metaDTO)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();


            ValidationResult resultadoValidacion = new MetaValidation().Validate(metaDTO);

            if (resultadoValidacion.IsValid)
            {
                metaDTO.Id = Guid.NewGuid().ToString();
                metaDTO.FechaCreacion = DateTime.Now;
                var resultadoDeGuardar = await MetaRepository.Crear(metaDTO.Adapt<Meta>());

                if (resultadoDeGuardar)
                {
                    respuestaDTO.Titulo = "Meta guardada.";
                    respuestaDTO.Tipo = Tipo.Exitoso;
                    respuestaDTO.Mensaje = "Se guardo la meta exitosamente.";
                }
                else
                {
                    respuestaDTO.Titulo = "Ya existe.";
                    respuestaDTO.Tipo = Tipo.Error;
                    respuestaDTO.Mensaje = "Elige un nombre distinto.";

                }

            }
            else
            {
                respuestaDTO.Titulo = "Inconsistencia en la información.";
                respuestaDTO.Tipo = Tipo.Error;
                respuestaDTO.Mensaje = "No cumple con las reglas de validación.";
            }

            return respuestaDTO;
        }

        public async Task<RespuestaDTO> Editar(MetaDTO metaDTO)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();

            ValidationResult resultadoValidacion = new MetaValidation().Validate(metaDTO);

            if (resultadoValidacion.IsValid)
            {
                var resultadoActualizacion = await MetaRepository.Editar(metaDTO.Adapt<Meta>());

                if (resultadoActualizacion)
                {
                    respuestaDTO.Titulo = "Meta actualizada.";
                    respuestaDTO.Tipo = Tipo.Exitoso;
                    respuestaDTO.Mensaje = "Se actualizó la meta exitosamente.";
                }
                else
                {
                    respuestaDTO.Titulo = "Problemas al actualizar la meta.";
                    respuestaDTO.Tipo = Tipo.Error;
                    respuestaDTO.Mensaje = "Por el momento no es posible guardar la meta, intentar más tarde.";
                }
            }
            else
            {
                respuestaDTO.Titulo = "Inconsistencia en la información.";
                respuestaDTO.Tipo = Tipo.Error;
                respuestaDTO.Mensaje = "No cumple con las reglas de validación.";
            }

            return respuestaDTO;
        }

        public async Task<RespuestaDTO> Eliminar(string idMeta)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();

            bool resultadoEliminacion = await MetaRepository.Eliminar(new Meta { Id = idMeta });

            if (resultadoEliminacion)
            {
                respuestaDTO.Titulo = "Meta eliminada.";
                respuestaDTO.Tipo = Tipo.Exitoso;
                respuestaDTO.Mensaje = "Se eliminó la meta y toda la información relacionada.";
            }
            else
            {
                respuestaDTO.Titulo = "Problemas para eliminar la meta.";
                respuestaDTO.Tipo = Tipo.Error;
                respuestaDTO.Mensaje = "Por el momento no es posible eliminar la meta, intentar más tarde.";
            }
             
        return respuestaDTO;
    }

    public Task<bool> ExisteNombreMeta(string nombre)
    {
            return MetaRepository.ExisteNombreMeta(nombre);
    }

    public async Task<List<DetalleMetaDTO>> Obtener()
    {
            List<DetalleMetaDTO> detalles = new List<DetalleMetaDTO>();
            try
            {
                var metas = await MetaRepository.ObtenerMetas();

                foreach (var meta in metas.OrderByDescending(x=>x.FechaCreacion))
                {
                    var actividadesConcluidas = meta.Actividades.Where(x => x.Concluida == true).Count();
                      var totalActividades = meta.Actividades.Count();

                    var porcentaje = totalActividades>0?(100 / totalActividades) * actividadesConcluidas:0;



                    detalles.Add(
                            new DetalleMetaDTO
                            {
                                Id=meta.Id,
                                Nombre=meta.Nombre,
                                FechaCreacion=meta.FechaCreacion,
                                porcentajeAvance=porcentaje,
                                actividadesConcluidas = actividadesConcluidas,
                                totalActividades = totalActividades,
                                
                            }
                            
                        );

                }



            }
            catch (Exception)
            {

                throw;
            }
            return detalles;
    }

        public async  Task<MetaDTO> ObtenerMeta(string id)
        {
            return (await(MetaRepository.ObtenerMetaPorId(id))).Adapt<MetaDTO>();
        }
    }
}
