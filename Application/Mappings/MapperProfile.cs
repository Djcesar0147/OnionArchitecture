using Application.Feautres.Persona.Commands.CreatePersonaCommand;
using Application.Feautres.Persona.Commands.UpdatePersonaCommand;
using Domain.Entities;

namespace Application.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Commans
            CreateMap<CreatePersonaCommand, Persona>();
            #endregion
        }
    }
}
