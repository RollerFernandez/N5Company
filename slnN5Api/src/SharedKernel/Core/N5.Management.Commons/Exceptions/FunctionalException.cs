namespace N5.Management.Commons.Exceptions
{
    [Serializable()]
    public class FunctionalException : N5Exception
    {
        public FunctionalException(string message) : base(StatusResponse.FUNCTIONAL_ERROR , message)
        {
        }

        public FunctionalException(string message, dynamic data) : base(StatusResponse.FUNCTIONAL_ERROR, message)
        {
            Data = data;
        }
    }
}
