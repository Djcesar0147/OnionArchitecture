namespace Domain.Common
{
    public class AuditableBaseEntity
    {
        public string CreadoPor { get; set; }
        public DateTime FechaCaptura { get; set; }
        public string? ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
