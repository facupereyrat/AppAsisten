using System.Net.Http;
using System.Threading.Tasks;

namespace AppAsist.Client.Servicios
{
    public class HttpRespuesta<T>
    {
        public T? Respuesta { get; set; }
        public bool Error { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public HttpRespuesta(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            this.Respuesta = response;
            this.Error = error;
            this.HttpResponseMessage = httpResponseMessage;
        }

        // Método para obtener el mensaje de error si lo hay
        public async Task<string> ObtenerError()
        {
            if (!Error)
            {
                return ""; // No hay error
            }

            var statusCode = HttpResponseMessage.StatusCode;

            // Dependiendo del código de estado, retornamos un mensaje de error adecuado
            switch (statusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    return "Error, no se puede procesar la información.";

                case System.Net.HttpStatusCode.Unauthorized:
                    return "Error, no está logueado.";

                case System.Net.HttpStatusCode.Forbidden:
                    return "Error, no tiene autorización para ejecutar este proceso.";

                case System.Net.HttpStatusCode.NotFound:
                    return "Error, dirección no encontrada.";

                case System.Net.HttpStatusCode.ServiceUnavailable:
                    return "El servicio está temporalmente no disponible. Intenta más tarde.";

                default:
                    // Devuelve el mensaje de error proveniente del cuerpo de la respuesta (si está disponible)
                    var content = await HttpResponseMessage.Content.ReadAsStringAsync();
                    return string.IsNullOrEmpty(content) ? "Error desconocido." : content;
            }
        }
    }
}
