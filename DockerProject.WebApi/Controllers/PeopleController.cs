using DockerProject.WebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace DockerProject.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeopleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _context.People.ToArray();
        }
    }
}
