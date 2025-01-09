namespace MyFirstApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [ApiController]
    [Route("[controller]")]
    public class LifetimeController : ControllerBase
    {
        private readonly ITransientService _transientService;
        private readonly IScoredService _scoredService;
        private readonly ISingletonService _singletonService;

        public LifetimeController(ITransientService transientService, IScoredService scoredService, ISingletonService singletonService)
        {
            _transientService = transientService;
            _scoredService = scoredService;
            _singletonService = singletonService;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            // NOTE : I  need a tool to log the lifetime of the services
            var scopedServiceMessage = _scoredService.SayHello();
            var singletonServiceMessage = _singletonService.SayHello();
            var transientServiceMessage = _transientService.SayHello();

            return Content($"{scopedServiceMessage}\n{singletonServiceMessage}\n{transientServiceMessage}");
        }
    }
}