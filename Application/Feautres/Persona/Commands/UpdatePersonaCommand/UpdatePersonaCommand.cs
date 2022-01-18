



namespace Application.Feautres.Persona.Commands.UpdatePersonaCommand
{
    public class UpdatePersonaCommand : IRequest<Response<object>>
    {
        public int persona_Id { get; set; }
        public string persona_APaterno { get; set; }
        public string persona_AMaterno { get; set; }
        public string persona_Nombres { get; set; }
        public DateTime? FechaNacimiento { get; set; }


        public class UpdatePersonaCommandHandler : IRequestHandler<UpdatePersonaCommand, Response<object>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Persona> _repositoryAsync;
            private readonly IMapper _mapper;

            public UpdatePersonaCommandHandler(IRepositoryAsync<Domain.Entities.Persona> repositoryAsync, IMapper mapper)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }

            public async Task<Response<object>> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
            {
                var persona = await _repositoryAsync.GetByIdAsync(request.persona_Id);
                if(persona == null)
                    throw new KeyNotFoundException($"Registro no encontrado con PersonaId={request.persona_Id}");

                //No usar automapper porque se debe insertar solo cambios en la data recibido (ej no se actualizaria fecha de creacion ni usuario de creacion)
                persona.persona_Nombres = request.persona_Nombres;
                persona.persona_APaterno = request.persona_APaterno;
                persona.persona_AMaterno = request.persona_AMaterno;
                persona.FechaNacimiento = request.FechaNacimiento;
                await _repositoryAsync.UpdateAsync(persona);
                return new Response<object>(request, persona.persona_Id, 0, "Ok");

            }
        } 
    }
}
