using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Persona.Commands.CreatePersonaCommand
{
    //https://docs.fluentvalidation.net/en/latest/aspnet.html
    public class CreatePersonaCommandValidator : AbstractValidator<CreatePersonaCommand>
    {
        public CreatePersonaCommandValidator()
        {
            RuleFor(x => x.persona_APaterno).NotNull();
            RuleFor(x => x.persona_AMaterno).Length(0, 10);
            //RuleFor(x => x.Email).EmailAddress();
          //  RuleFor(x => x.Age).InclusiveBetween(18, 60);
            RuleFor(x => x.persona_Nombres).NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                                         .MaximumLength(200).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
