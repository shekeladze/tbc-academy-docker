using DockerProject.WebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace DockerProject.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly AppDbContext _context;

        public PeopleController(ILogger<PeopleController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var data = _context.People.ToArray();

            _logger.LogInformation("People selected: {Length}", data.Length);

            return data;
        }
    }
}
