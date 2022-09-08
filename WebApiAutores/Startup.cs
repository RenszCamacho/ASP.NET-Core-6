using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiAutores.Servicios;

namespace WebApiAutores
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services
                .AddDbContext<ApplicationDbContext>(options =>
                    options
                        .UseSqlServer(Configuration.GetConnectionString("defaultConnection"))
                 );

            // Transitorio no ocupa estado, es una instancia distinta, aunque se dentro del mismo contexto http.
            // Scope si vas a trabajar siempre con los mismos datos, es la misma instancia dentro del mismo contexto.
            // Singleton si va a tener la misma data compartida entre todos, es la misma instancia de la clase.
            services.AddTransient<IServicio, ServicioA>();

            services.AddTransient<ServicioTransient>();
            services.AddScoped<ServicioScoped>();
            services.AddSingleton<ServicioSingleton>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
