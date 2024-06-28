
namespace N5.Management.Commons.Exceptions
{
    public class N5Exception : Exception, ISerializable
    {
        public string TransactionId { get; }
        public int Status { get; }
        public dynamic? Data { get; set; }

        public N5Exception(int statusCode, string message) : base(message)
        {
            Status = statusCode;
            TransactionId = DateTime.Now.ToString(Constants.Core.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF);
        }
    }
}
