namespace N5.Management.Commons.Configurations
{
    public class AppSettings
    {
        public const string Name = "AppSettings";
        public DatabaseConfiguration DatabaseConfiguration { get; set; }
        public JwTokenConfiguration JWTokenConfiguration { get; set; }
        public N5Configuration N5Configuration { get; set; }
        public CacheConfiguration CacheConfiguration { get; set; }
    }
}
