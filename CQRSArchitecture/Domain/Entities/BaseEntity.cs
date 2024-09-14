namespace CQRSArchitecture.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
    }
}
