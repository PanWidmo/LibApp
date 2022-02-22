using FluentValidation;
using LibApp.Data;
using LibApp.Dtos;
using System.Linq;

namespace LibApp.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(5);

            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password);

            RuleFor(x=>x.Email)
                .Custom((value,context) => {
                    var emailInUse = dbContext.Customers.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Given email address is already in use");
                    }
                });
        }
    }
}
