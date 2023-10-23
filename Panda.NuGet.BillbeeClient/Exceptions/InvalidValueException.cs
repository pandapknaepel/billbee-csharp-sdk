namespace Panda.NuGet.BillbeeClient.Exceptions
{
    /// <summary>
    /// Exception thrown, when an parametervalue was not correct or malformed.
    /// </summary>
    public class InvalidValueException: Exception
    {
        public InvalidValueException(string message): base(message)
        {

        }
    }
}
