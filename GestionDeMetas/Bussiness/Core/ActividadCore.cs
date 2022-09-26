using FluentValidation;
using FluentValidation.Results;
using GestionDeMetas.Bussiness.ICore;
using GestionDeMetas.Bussiness.IRepository;
using GestionDeMetas.Bussiness.Persistence.Models;
using GestionDeMetas.Bussiness.Repository;
using GestionDeMetas.Shared.DTO.Actividad;
using GestionDeMetas.Shared.DTO.Genericos;
using GestionDeMetas.Shared.DTO.Meta;
using GestionDeMetas.Shared.Validation;
using GestionDeMetas.Shared.Validations;
using Mapster;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Bussiness.Core
{
    public class ActividadCore : IActividadCore
    {

        public ActividadCore(IActividadRepository actividadRepository)
        {
            ActividadRepository = actividadRepository;
        }

        public IActividadRepository ActividadRepository { get; }

        public async Task<RespuestaDTO> Concluir(List<string> ids)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();
            int concluidas = 0;

            foreach (var id in ids)
            {
                   var resultado= await ActividadRepository.Concluir(id);

                if (resultado)
                {

                    concluidas++;
                }

            }
                

            if (concluidas>0)
            {
                respuestaDTO.Titulo = concluidas==1? "Actividad concluida.":$"Actividades concluidas";
                respuestaDTO.Tipo = Tipo.Exitoso;
                respuestaDTO.Mensaje = concluidas == 1 ? "La actividad fue concluida.":$"{concluidas} fueron concluidas.";
            }
            else
            {
                respuestaDTO.Titulo = "Problemas para concluir la actividad.";
                respuestaDTO.Tipo = Tipo.Error;
                respuestaDTO.Mensaje = "Por el momento no es posible concluir la actividad, intentar más tarde.";
            }

            return respuestaDTO;
        }

        public async Task<RespuestaDTO> Crear(ActividadDTO actividadDTO)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();


            ValidationResult resultadoValidacion = new ActividadValidation().Validate(actividadDTO);

            if (resultadoValidacion.IsValid)
            {
                actividadDTO.Id = Guid.NewGuid().ToString();
                actividadDTO.FechaCreacion = DateTime.Now;
                var resultadoDeGuardar = await ActividadRepository.Crear(actividadDTO.Adapt<Actividad>());

                if (resultadoDeGuardar)
                {
                    respuestaDTO.Titulo = "Actividad guardada.";
                    respuestaDTO.Tipo = Tipo.Exitoso;
                    respuestaDTO.Mensaje = "Se guardo la actividad exitosamente.";
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

        public async Task<RespuestaDTO> Destacar(string id)
        {

            RespuestaDTO respuestaDTO = new RespuestaDTO();

            bool resultado = await ActividadRepository.Destacar( id);

            if (resultado)
            {
                respuestaDTO.Titulo = "Actividad destacada.";
                respuestaDTO.Tipo = Tipo.Exitoso;
                respuestaDTO.Mensaje = "La actividad fue definida como destacada.";
            }
            else
            {
                respuestaDTO.Titulo = "Problemas para destacar la actividad.";
                respuestaDTO.Tipo = Tipo.Error;
                respuestaDTO.Mensaje = "Por el momento no es posible destacar la actividad, intentar más tarde.";
            }

            return respuestaDTO;
        }

        public async Task<RespuestaDTO> Editar(ActividadDTO actividadDTO)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();


            ValidationResult resultadoValidacion = new ActividadValidation().Validate(actividadDTO);

            if (resultadoValidacion.IsValid)
            {
                 
                var resultadoDeGuardar = await ActividadRepository.Editar(actividadDTO.Adapt<Actividad>());

                if (resultadoDeGuardar)
                {
                    respuestaDTO.Titulo = "Actividad actualizada.";
                    respuestaDTO.Tipo = Tipo.Exitoso;
                    respuestaDTO.Mensaje = "Se guardarón los cambios exitosamente.";
                }
                else
                {
                    respuestaDTO.Titulo = "Problemas al actualizar la actividad.";
                    respuestaDTO.Tipo = Tipo.Error;
                    respuestaDTO.Mensaje = "Por el momento no es posible actualizar la información de la actividad, intentar más tarde.";
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

        public async Task<RespuestaDTO> Eliminar(List<string> ids)
        {
            RespuestaDTO respuestaDTO = new RespuestaDTO();

            bool resultadoEliminacion = await ActividadRepository.Eliminar(ids);

            if (resultadoEliminacion)
            {
                respuestaDTO.Titulo = ids.Count>1?"Actividades eliminadas. ": "Actividad eliminada.";
                respuestaDTO.Tipo = Tipo.Exitoso;
                respuestaDTO.Mensaje = ids.Count>1?$"Se eliminaron {ids.Count}  actividades.":"Se eliminó la actividad.";
            }
            else
            {
                respuestaDTO.Titulo = ids.Count>1?$"Problemas para eliminar las actividades.":"Problemas para elminar la actividad.";
                respuestaDTO.Tipo = Tipo.Error;
                respuestaDTO.Mensaje = "Por el momento no es posible realizar la acción, intentar más tarde.";
            }

            return respuestaDTO;
        }

        public async Task<List<ActividadDTO>> ObtenerActividadesPorMeta(string idMeta)
        {
            try
            {
                var resultado = (await(ActividadRepository.ObtenerActividadesPorMeta(idMeta))).Adapt<List<ActividadDTO>>(); 

                return resultado;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActividadDTO> ObtenerActividadPorId(string id)
        {
            return (await(ActividadRepository.ObtenerActividadPorId(id))).Adapt<ActividadDTO>();
        }
    }
}
