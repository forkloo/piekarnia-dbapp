using FluentValidation;
using Piekarnia.Api.BindingModels;

namespace Piekarnia.Api.Validation
{
    public class CreateClientValidator : AbstractValidator<CreateClient>
    {
        public CreateClientValidator(){
            RuleFor(x => x.ClientName).NotNull();
            RuleFor(x => x.ClientSurname).NotNull();
            RuleFor(x => x.ClientCity).NotNull();
            RuleFor(x => x.ClientMail).NotNull().EmailAddress();
        }
    }
}
