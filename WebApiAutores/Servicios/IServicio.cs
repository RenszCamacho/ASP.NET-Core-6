namespace WebApiAutores.Servicios
{
    public interface IServicio
    {
        Guid ObternerScoped();
        Guid ObternerSingleton();
        Guid ObternerTransient();
        void RealizarTarea();
    }

    public class ServicioA : IServicio
    {
        private readonly ILogger<ServicioA> _logger;
        private readonly ServicioTransient _servicioTransient;
        private readonly ServicioScoped _servicioScoped;
        private readonly ServicioSingleton _servicioSingleton;

        public ServicioA(
            ILogger<ServicioA> logger,
            ServicioTransient servicioTransient,
            ServicioScoped servicioScoped,
            ServicioSingleton servicioSingleton
            )
        {
            _logger = logger;
            _servicioTransient = servicioTransient;
            _servicioScoped = servicioScoped;
            _servicioSingleton = servicioSingleton;
        }

        public Guid ObternerTransient() { return _servicioTransient.Guid; }
        public Guid ObternerScoped() { return _servicioScoped.Guid; }
        public Guid ObternerSingleton() { return _servicioSingleton.Guid; }

        public void RealizarTarea()
        {
            throw new NotImplementedException();
        }
    }

    public class ServicioB : IServicio
    {
        public Guid ObternerScoped()
        {
            throw new NotImplementedException();
        }

        public Guid ObternerSingleton()
        {
            throw new NotImplementedException();
        }

        public Guid ObternerTransient()
        {
            throw new NotImplementedException();
        }

        public void RealizarTarea()
        {

        }
    }

    public class ServicioTransient 
    {
       public Guid Guid = Guid.NewGuid();
    }

    public class ServicioScoped
    {
        public Guid Guid = Guid.NewGuid();
    }

    public class ServicioSingleton
    {
        public Guid Guid = Guid.NewGuid();
    }
}
