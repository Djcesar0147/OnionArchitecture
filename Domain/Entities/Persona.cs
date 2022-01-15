

namespace Domain.Entities
{
    [Table("Persona")]
    public class Persona : AuditableBaseEntity
    {
        [Key]
        public int persona_Id { get; set; }

        [MaxLength(200)]
        public string persona_APaterno { get; set; }

        [MaxLength(200)]
        public string persona_AMaterno { get; set; }

        public string persona_Nombres{ get; set; }
        public DateTime? FechaNacimiento { get; set; }

    }
}
