using FluentValidation;
using Simple_API_Domain.Handlers.Test;

namespace Simple_API_Domain.Validation
{
    public class TestValidation : AbstractValidator<TestRequest>
    {
        public TestValidation()
        {
            //RuleFor(v => v.)
            //    .NotEmpty();
        }
    }
}