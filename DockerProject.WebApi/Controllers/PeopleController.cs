using DockerProject.WebApi.Data;
using DockerProject.WebApi.Diags;
using DockerProject.WebApi.Models;
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

        [HttpPost]
        public IActionResult Create(PersonDto person)
        {
            var newPerson = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = DateOnly.FromDateTime(person.DateOfBirth),
            };

            _context.People.Add(newPerson);

            _context.SaveChanges();

            DiagnosticConfigs.RegistrationsCounter.Add(
                1, 
                new KeyValuePair<string, object?>("person.age", AgeInYears(person.DateOfBirth)));

            return Ok(newPerson);
        }

        private int AgeInYears(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dateOfBirth.Year;
            if (dateOfBirth.AddYears(age) > now)
                age--;
            return age;
        }
    }
}
