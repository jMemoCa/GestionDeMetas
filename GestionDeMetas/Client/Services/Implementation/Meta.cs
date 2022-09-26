using GestionDeMetas.Client.Helpers.Interface;
using GestionDeMetas.Client.Services.Interface;
using GestionDeMetas.Shared;
using GestionDeMetas.Shared.DTO.Genericos;
using GestionDeMetas.Shared.DTO.Meta;
 
using System;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace GestionDeMetas.Client.Services.Implementation
{
    public class Meta : IMeta
    {
        public Meta(HttpClient Http ,IEventos eventos )
        {
            this.Http = Http;
            Eventos = eventos;
        }

        public HttpClient Http { get; }
        public IEventos Eventos { get; } 

        public async Task<bool> Crear(MetaDTO metaDTO)
        {
            try
            {
                var respose = await Http.PostAsJsonAsync("Meta/", metaDTO);
                var respuesta = await respose.Content.ReadFromJsonAsync<RespuestaDTO>();


                Eventos.MostrarNofificacion(respuesta);
            }
            catch (Exception ex)
            {


            }
            return true;
        }

        public async Task<bool> Editar(MetaDTO metaDTO)
        {
            try
            {
                var respose = await Http.PutAsJsonAsync("Meta/", metaDTO);
                var respuesta = await respose.Content.ReadFromJsonAsync<RespuestaDTO>();


                Eventos.MostrarNofificacion(respuesta);
            }
            catch (Exception ex)
            {


            }
            return true;
        }

        public async Task<bool> Eliminar(string id)
        {
            try
            {
                var respose = await Http.DeleteAsync($"Meta/Eliminar/{id}");
                var respuesta = await respose.Content.ReadFromJsonAsync<RespuestaDTO>();
                Eventos.MostrarNofificacion(respuesta);
            }
            catch (Exception)
            {
                 
            }

            return true;


        }

        public async Task<MetaDTO> ObtenerMeta(string id)
        {

            try
            {
                return await Http.GetFromJsonAsync<MetaDTO>($"Meta/ObtenerMeta/{id}");
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<DetalleMetaDTO>> ObtenerMetas()
        {
            List<DetalleMetaDTO> metas = new List<DetalleMetaDTO>();
            try
            {
                metas = await Http.GetFromJsonAsync<List<DetalleMetaDTO>>("Meta/ObtenerMetas/");
            }
            catch (Exception)
            {

            }

            return metas;

        }
    }
}
