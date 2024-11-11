using System.Net.Http;
using System.Threading.Tasks;

namespace AppAsist.Client.Servicios
{
    public class AsistenciaService
    {
        private readonly HttpClient httpClient;

        public AsistenciaService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // Método para validar la entrada del miembro
        public async Task<HttpRespuesta<bool>> ValidarEntradaAsync(string qrCode)
        {
            try
            {
                // Enviar solicitud GET al servidor para validar la entrada
                var response = await httpClient.GetAsync($"api/asistencia/entrada/{qrCode}");

                // Si la respuesta es exitosa, retornamos HttpRespuesta con 'true' y sin error
                if (response.IsSuccessStatusCode)
                {
                    return new HttpRespuesta<bool>(true, false, response);
                }

                // Si la respuesta es un error, retornamos HttpRespuesta con 'false' y error
                return new HttpRespuesta<bool>(false, true, response);
            }
            catch (HttpRequestException)
            {
                // Si hay problemas de conexión o error en la solicitud, retornamos un error genérico
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    ReasonPhrase = "No se pudo acceder al servidor. Verifica tu conexión a internet."
                };
                return new HttpRespuesta<bool>(false, true, response);
            }
        }

        // Método para validar la salida del miembro
        public async Task<HttpRespuesta<bool>> ValidarSalidaAsync(string qrCode)
        {
            try
            {
                // Enviar solicitud GET al servidor para validar la salida
                var response = await httpClient.GetAsync($"api/asistencia/salida/{qrCode}");

                // Si la respuesta es exitosa, retornamos HttpRespuesta con 'true' y sin error
                if (response.IsSuccessStatusCode)
                {
                    return new HttpRespuesta<bool>(true, false, response);
                }

                // Si la respuesta es un error, retornamos HttpRespuesta con 'false' y error
                return new HttpRespuesta<bool>(false, true, response);
            }
            catch (HttpRequestException)
            {
                // Si hay problemas de conexión o error en la solicitud, retornamos un error genérico
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    ReasonPhrase = "No se pudo acceder al servidor. Verifica tu conexión a internet."
                };
                return new HttpRespuesta<bool>(false, true, response);
            }
        }
    }
}
