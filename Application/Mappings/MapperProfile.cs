
using Application.Feautres.Persona.Commands.CreatePersonaCommand;
using Application.Feautres.Persona.Commands.UpdatePersonaCommand;
using Domain.Entities;

namespace Application.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region DTOs
            CreateMap<Persona, PersonaDto>();
            #endregion


            #region Commans
            CreateMap<CreatePersonaCommand, Persona>();
            #endregion
        }
    }
}
