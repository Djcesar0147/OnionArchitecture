
using Application.Interfaces;


namespace Application.Feautres.Persona.Commands.CreatePersonaCommand
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
            private readonly IRepositoryAsync<Domain.Entities.Persona> _repositoryAsync;
            private readonly IMapper _mapper;

            public CreatePersonaCommandHandler(IRepositoryAsync<Domain.Entities.Persona> repositoryAsync, IMapper mapper)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }


            public async Task<Response<int>> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
            {
                var nuevaPersona = _mapper.Map<Domain.Entities.Persona>(request);
                var data = await _repositoryAsync.AddAsync(nuevaPersona);

                return new Response<int>(data.persona_Id);
            }
        }

    }
}

