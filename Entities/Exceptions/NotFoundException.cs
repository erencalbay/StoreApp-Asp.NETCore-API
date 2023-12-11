
namespace Entities.Exceptions
{
    //abstract: herhangi bir şekilde tanımlama olmayacak
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message)
        {
            
        }

    }
}
