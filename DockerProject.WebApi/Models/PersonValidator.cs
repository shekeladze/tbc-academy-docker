using FluentValidation;

namespace DockerProject.WebApi.Models
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth)
                .InclusiveBetween(DateTime.UtcNow.AddYears(-75), DateTime.UtcNow.AddYears(-18));
        }
    }
}
