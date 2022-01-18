namespace Application.DTOs
{
    public class PersonaDto
    {
        public int persona_Id { get; set; }
        public string persona_APaterno { get; set; }
        public string persona_AMaterno { get; set; }
        public string persona_Nombres { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
