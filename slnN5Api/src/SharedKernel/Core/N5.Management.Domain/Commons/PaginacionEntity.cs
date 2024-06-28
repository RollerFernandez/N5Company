namespace N5.Management.Domain.Commons
{
    public class PaginacionEntity<T>
    {
        public List<T>? Items { get; set; }
        public int Total { get; set; }
        public int Pages { get; set; }
    }
}

