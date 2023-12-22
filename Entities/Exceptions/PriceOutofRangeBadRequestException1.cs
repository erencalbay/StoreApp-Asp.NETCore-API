namespace Entities.Exceptions
{
    public class PriceOutofRangeBadRequestException : BadRequestExcepiton
    {
        public PriceOutofRangeBadRequestException() : base("Maximum price should be less than 1000 and greater than 10")
        {

        }
    }
}
