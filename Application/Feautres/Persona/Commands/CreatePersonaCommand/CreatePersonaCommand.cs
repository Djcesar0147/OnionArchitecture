
using Application.Interfaces;


namespace Application.Feautres.Persona.Commands.CreatePersonaCommand
{
    public class CreatePersonaCommand : IRequest<Response<object>>
    {
        public int persona_Id { get; set; }
        public string persona_APaterno { get; set; }
        public string persona_AMaterno { get; set; }
        public string persona_Nombres { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, Response<object>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Persona> _repositoryAsync;
            private readonly IMapper _mapper;

            public CreatePersonaCommandHandler(IRepositoryAsync<Domain.Entities.Persona> repositoryAsync, IMapper mapper)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }


            public async Task<Response<object>> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
            {
                var nuevaPersona = _mapper.Map<Domain.Entities.Persona>(request);
                var data = await _repositoryAsync.AddAsync(nuevaPersona);
                request.persona_Id = data.persona_Id;
                return new Response<object>(request, data.persona_Id, 0, "Ok");

            }
        }

    }
}

