namespace N5.Management.Commons.Configurations.Base
{
    public class ServiceConfiguration
    {
        public string Url { get; set; }
        public CredentialConfiguration Credentials { get; set; }
    }

    public partial class Portal
    {
        public string Url { get; set; }
    }

    public partial class CredentialConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
