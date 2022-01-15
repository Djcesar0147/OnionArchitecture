
namespace Application.Feautres.Persona.Commands
{
    public class CreatePersonaCommand : IRequest<Response<int>>
    {
        public int persona_Id { get; set; }
        public string persona_APaterno { get; set; }
        public string persona_AMaterno { get; set; }
        public string persona_Nombres { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, Response<int>>
        {
            public async Task<Response<int>> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

    }
}

