using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Persona.Commands.DeletePersonaCommand
{
    public class DeletePersonaCommandValidator : AbstractValidator<DeletePersonaCommand>
    {
        public DeletePersonaCommandValidator()
        {
            RuleFor(x => x.persona_Id).NotEmpty().WithMessage("{PropertyName} es requerido");
        }
    }
}
