using GestionDeMetas.Shared.DTO.Genericos;

namespace GestionDeMetas.Client.Helpers.Interface
{
    public interface IEventos
    {
        /// <summary>
        /// Permite enviar notificaciones de las acciones.
        /// </summary>
        /// <param name="respuesta">Según los valores de la respuesta es el mensaje que se estará mostrando</param>
        void MostrarNofificacion(RespuestaDTO respuesta);
    }
}
