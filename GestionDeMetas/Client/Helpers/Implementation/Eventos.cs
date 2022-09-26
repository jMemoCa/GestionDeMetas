using GestionDeMetas.Client.Helpers.Interface;
using GestionDeMetas.Shared.DTO.Genericos;
using Radzen;

namespace GestionDeMetas.Client.Helpers.Implementation
{
    public class Eventos : IEventos
    {
        public Eventos(NotificationService NotificationService)
        {
            this.NotificationService = NotificationService;
        }

        public NotificationService NotificationService { get; }

     
        /// <summary>
        /// Permite mostrar los mensajes dependiendo de la respuesta retornada en los distintos eventos,
        /// permite hacer match entre los estatus de radzen con los que se utilizan a nivel negoción.
        /// </summary>
        /// <param name="respuesta">Parametro que permite enviar los mensajes según sean los valores recibidos</param>
        public void MostrarNofificacion(RespuestaDTO respuesta)
        {
            NotificationMessage notificacion = new NotificationMessage();
            notificacion.Summary = respuesta.Titulo ?? "";
            notificacion.Detail = respuesta.Mensaje ?? "";
            notificacion.Duration = 4000; 
             
            switch (respuesta.Tipo)
            {
                case Tipo.Error:
                    notificacion.Severity= NotificationSeverity.Error;
                    break;
                case Tipo.Informativo:
                    notificacion.Severity = NotificationSeverity.Info;
                    break;
                case Tipo.Exitoso:
                    notificacion.Severity = NotificationSeverity.Success;
                    break;
                case Tipo.Advertencia:
                    notificacion.Severity = NotificationSeverity.Warning;
                    break;
                default:
                    break;
            }

            NotificationService.Notify(notificacion);

         
        }
    }
}
