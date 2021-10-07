using FluentValidation;
using Simple_API_Domain.Commands;

namespace Simple_API_Domain.Validation
{
    public class TestValidation : AbstractValidator<TestCommand>
    {
        public TestValidation()
        {
            //RuleFor(v => v.)
            //    .NotEmpty();
        }
    }
}