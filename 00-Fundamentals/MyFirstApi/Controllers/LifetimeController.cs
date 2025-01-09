namespace MyFirstApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [ApiController]
    [Route("[controller]")]
    public class LifetimeController(
        ITransientService _transientService,
        IScoredService _scoredService,
        ISingletonService _singletonService) : ControllerBase
    {
        // Additional methods and members can still be defined here
        [HttpGet]
        public ActionResult<string> Get()
        {
            // NOTE : Use HttpRepl
            var scopedServiceMessage = _scoredService.SayHello();
            var singletonServiceMessage = _singletonService.SayHello();
            var transientServiceMessage = _transientService.SayHello();

            return Content($"{scopedServiceMessage}\n{singletonServiceMessage}\n{transientServiceMessage}");
        }

        [HttpGet("action-injection")]
        public ActionResult<string> GetActionInjection([FromServices] ITransientService transientService)
        {
            var transientServiceMessage = _transientService.SayHello();

            return Content($"{transientServiceMessage}");
        }

    }
}