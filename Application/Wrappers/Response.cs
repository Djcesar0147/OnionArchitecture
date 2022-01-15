namespace Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {

        }
        public Response(T data, string message = null)
        {
            Result = true;
            Mensaje = message;
            Datos = data;
        }

        public Response(string message, T data, List<string> lstErrores, int ejec = -1)
        {
            Result = false;
            Mensaje = message;
            Datos = data;
            Ejecucion = ejec;
            Errores = lstErrores;
        }

        public int Ejecucion { get; set; }
        public bool Result { get; set; }
        public string? Mensaje { get; set; }
        public List<string> Errores { get; set; }
        public T Datos { get; set; }
        public int Identificador { get; set; }
        public long BIdentificador { get; set; }
    }
}
