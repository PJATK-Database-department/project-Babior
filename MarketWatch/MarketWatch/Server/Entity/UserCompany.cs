using MarketWatch.Server.Entities;

namespace MarketWatch.Server.Entity
{
    public class UserCompany
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}