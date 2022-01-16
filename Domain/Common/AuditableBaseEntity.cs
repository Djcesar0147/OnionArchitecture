namespace Domain.Common
{
    public class AuditableBaseEntity
    {
        [MaxLength(200)]
        public string? CreadoPor { get; set; }

        public DateTime FechaCaptura { get; set; }

        [MaxLength(200)]
        public string? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
