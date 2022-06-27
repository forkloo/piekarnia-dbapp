using FluentValidation;
using Piekarnia.Api.BindingModels;

namespace Piekarnia.Api.Validation
{
    public class DeleteClientValidator : AbstractValidator<DeleteClient>
    {
        public DeleteClientValidator(){
            RuleFor(x => x.ClientId).NotNull();
        }
    }
}
