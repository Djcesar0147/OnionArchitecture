using Application.DTOs;

namespace Application.Feautres.Persona.Queries.GetPersonaById
{
    public class GetPersonaByIdQuery : IRequest<Response<PersonaDto>>
    {
        public int personaId { get; set; }

        public class GetPersonaByIdQueryHandler : IRequestHandler<GetPersonaByIdQuery, Response<PersonaDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Persona> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetPersonaByIdQueryHandler(IRepositoryAsync<Domain.Entities.Persona> repositoryAsync, IMapper mapper)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }

            public async Task<Response<PersonaDto>> Handle(GetPersonaByIdQuery request, CancellationToken cancellationToken)
            {
                var persona = await _repositoryAsync.GetByIdAsync(request.personaId);
                if (persona == null)
                    throw new KeyNotFoundException($"Registro no encontrado con PersonaId={request.personaId}");

                var dto = _mapper.Map<PersonaDto>(persona);
                return new Response<PersonaDto>(dto, request.personaId, 0, "Ok");
            }
        }
    }
}
