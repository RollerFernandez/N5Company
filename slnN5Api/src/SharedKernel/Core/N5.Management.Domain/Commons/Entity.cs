using N5.Management.Commons;

namespace N5.Management.Domain.Commons
{
    public class Entity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = Constants.Core.Audit.CREATION_USER;
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Status { get; set; } = Constants.Core.UserStatus.ACTIVE;
    }
}

