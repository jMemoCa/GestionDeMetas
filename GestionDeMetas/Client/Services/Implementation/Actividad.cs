using GestionDeMetas.Client.Helpers.Interface;
using GestionDeMetas.Client.Services.Interface;
using GestionDeMetas.Shared.DTO.Actividad;
using GestionDeMetas.Shared.DTO.Genericos;
using GestionDeMetas.Shared.DTO.Meta;
using System.Net.Http.Json;

namespace GestionDeMetas.Client.Services.Implementation
{
    public class Actividad:IActividad
    {
        public Actividad(HttpClient Http, IEventos eventos)
        {
            this.Http = Http;
            Eventos = eventos;
        }

        public HttpClient Http { get; }
        public IEventos Eventos { get; }
         

        public async Task<bool> Crear(ActividadDTO actividadDTO)
        {
            try
            {
                var respose = await Http.PostAsJsonAsync("Actividad/", actividadDTO);
                var respuesta = await respose.Content.ReadFromJsonAsync<RespuestaDTO>();


                Eventos.MostrarNofificacion(respuesta);
            }
            catch (Exception ex)
            {


            }
            return true;
        }

   

        public async Task<bool> Editar(ActividadDTO actividadDTO)
        {
            try
            {
                var respose = await Http.PutAsJsonAsync("Actividad/", actividadDTO);
                var respuesta = await respose.Content.ReadFromJsonAsync<RespuestaDTO>();


                Eventos.MostrarNofificacion(respuesta);
            }
            catch (Exception ex)
            {


            }
            return true;
        }

        public async Task<bool> Eliminar(List<string> ids)
        {
            try
            {
                var respose = await Http.PostAsJsonAsync<List<string>>($"Actividad/Eliminar",ids);
                var respuesta = await respose.Content.ReadFromJsonAsync<RespuestaDTO>();
                Eventos.MostrarNofificacion(respuesta);
            }
            catch (Exception)
            {

            }

            return true;


        }

        public async Task<ActividadDTO> ObtenerActividad(string id)
        {
            ActividadDTO actividad = new ActividadDTO() ;
            try
            {
                actividad = await Http.GetFromJsonAsync<ActividadDTO>($"Actividad/ObtenerActividad/{id}");
            }
            catch (Exception)
            {

            }

            return actividad;

        }
      

        public async Task<List<ActividadDTO>> ObtenerActividadesPorMeta(string idMeta)
        {
            List<ActividadDTO> actividades = new List<ActividadDTO>();
            try
            {
                actividades = await Http.GetFromJsonAsync<List<ActividadDTO>>($"Actividad/ObtenerActividadesPorMeta/{idMeta}/");
            }
            catch (Exception)
            {

            }

            return actividades;
        }

        public async  Task<bool> Destacar(string id)
        {
            try
            {
                var respuesta = await Http.GetFromJsonAsync<RespuestaDTO>($"Actividad/Destacar/{id}");
                    Eventos.MostrarNofificacion(respuesta);

                return respuesta.Tipo == Tipo.Exitoso;
            }
            catch (Exception)
            {
                return false;
            }
             
        }

        public async Task<bool> Concluir(List<string> ids)
        {
            try
            {
                var respuesta = await Http.PostAsJsonAsync<List<string>>($"Actividad/Concluir",ids);
                var respuestaDTO = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO>();

                Eventos.MostrarNofificacion(respuestaDTO);

                return respuestaDTO.Tipo == Tipo.Exitoso;
            }
            catch (Exception)
            {
                return false;
            }
        }

       
    }
}
