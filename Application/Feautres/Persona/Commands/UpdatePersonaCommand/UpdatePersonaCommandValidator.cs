

namespace Application.Feautres.Persona.Commands.UpdatePersonaCommand
{
    public class UpdatePersonaCommandValidator : AbstractValidator<UpdatePersonaCommand>
    {
        public UpdatePersonaCommandValidator()
        {
            RuleFor(x => x.persona_Id).NotEmpty().WithMessage("{PropertyName} es requerido");
            RuleFor(x => x.persona_AMaterno).NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                                         .MaximumLength(200).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
            //RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.persona_Nombres).NotEmpty().WithMessage("{PropertyName} no puede ser vacío")
                                         .MaximumLength(200).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
