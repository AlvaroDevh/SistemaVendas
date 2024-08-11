namespace SistemaVendas.Services.Exception
{
    public class NotFoundException : ApplicationException
    {

        public NotFoundException (string message) : base(message)
        {

        }
    }
}
