using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Se ha producido uno o más errores de validación")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; }

        public ValidationException(IEnumerable<ValidationFailure> farirures) : this()
        {
            foreach (var farirure in farirures)
            {
                Errors.Add(farirure.ErrorMessage);
            }
        }
    }
}
