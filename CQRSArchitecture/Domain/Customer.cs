using CQRSArchitecture.Domain.Entities;

namespace CQRSArchitecture.Domain
{
    public class Customer : BaseEntity
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }

        public List<Order> Orders { get; set; }



    }
}
