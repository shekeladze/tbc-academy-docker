using Bogus;

namespace DockerProject.WebApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.People.Any())
            {
                return; // already seeded
            }

            var personFaker = new Faker<Person>()
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.DateOfBirth, f => f.Date.PastDateOnly(60, DateOnly.FromDateTime(DateTime.Now.AddYears(-18))));

            var people = personFaker.Generate(100);

            foreach (Person p in people)
            {
                context.People.Add(p);
            }

            context.SaveChanges();
        }
    }
}
