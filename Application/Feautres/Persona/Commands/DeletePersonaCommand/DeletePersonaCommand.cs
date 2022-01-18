using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Persona.Commands.DeletePersonaCommand
{
    public class DeletePersonaCommand : IRequest<Response<int>>
    {
        public int persona_Id { get; set; }

        public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand, Response<int>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Persona> _repositoryAsync;
            private readonly IMapper _mapper;

            public DeletePersonaCommandHandler(IRepositoryAsync<Domain.Entities.Persona> repositoryAsync, IMapper mapper)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }

            public async Task<Response<int>> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
            {
                var persona = await _repositoryAsync.GetByIdAsync(request.persona_Id);
                if (persona == null)
                    throw new KeyNotFoundException($"Registro no encontrado con PersonaId={request.persona_Id}");

                await _repositoryAsync.DeleteAsync(persona);
                return new Response<int>(persona.persona_Id, persona.persona_Id, 0, "Registro eliminado correctamente");
            }
        }
    }
}
