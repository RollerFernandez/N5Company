namespace N5.Management.Commons.Exceptions
{
    [Serializable()]
    public class TechnicalException : N5Exception
    {
        public TechnicalException(string message) : base(StatusResponse.TECNICAL_ERROR, message)
        {
        }

        public TechnicalException(string message, dynamic data) : base(StatusResponse.TECNICAL_ERROR, message)
        {
            Data = data;
        }
    }
}
