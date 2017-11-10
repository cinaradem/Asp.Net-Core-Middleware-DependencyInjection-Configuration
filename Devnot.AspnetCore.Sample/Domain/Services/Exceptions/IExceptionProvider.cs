namespace Devnot.AspnetCore.Sample.Domain.Services.Exceptions
{
    public interface IExceptionProvider
    {
        void Write(System.Exception exception);
    }
}
