namespace WebApiAutores.Middlewares
{
    public class LogearRespuestaHTTPMiddleware
    {
        private readonly RequestDelegate siguiente;
        private readonly ILogger<LogearRespuestaHTTPMiddleware> logger;

        public LogearRespuestaHTTPMiddleware(RequestDelegate siguiente, ILogger<LogearRespuestaHTTPMiddleware> logger)
        {
            this.siguiente = siguiente;
            this.logger = logger;
        }

          public async Task InvokeAsync(HttpContext context)
          {
              using (var ms = new MemoryStream())
              {
                  var cuerpoOriginalRespuesta = context.Response.Body;
                  context.Response.Body = ms;

                  await siguiente(context);

                  ms.Seek(0, SeekOrigin.Begin);
                  string respuesta = new StreamReader(ms).ReadToEnd();
                  ms.Seek(0, SeekOrigin.Begin);

                  await ms.CopyToAsync(cuerpoOriginalRespuesta);
                  context.Response.Body = cuerpoOriginalRespuesta;

                  logger.LogInformation(respuesta);
              }
          }
    }
}
