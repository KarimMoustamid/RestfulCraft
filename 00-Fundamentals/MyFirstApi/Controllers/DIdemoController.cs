namespace MyFirstApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [ApiController]
    [Route("api/DependencyInjectionDemo")]
    public class DIdemoController : ControllerBase
    {
        private readonly IDemoService _demoService;

        public DIdemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Content(_demoService.SayHello());
        }
    }
}