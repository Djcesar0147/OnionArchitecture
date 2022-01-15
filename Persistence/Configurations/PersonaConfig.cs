using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PersonaConfig : IEntityTypeConfiguration<Persona>
    {
        //Clase solo de ejemplo las demas configuracion se definen con Decoradores en la Clase de la entidad
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.Property(p => p.persona_Nombres)
                .HasMaxLength(200);
        }
    }
}
