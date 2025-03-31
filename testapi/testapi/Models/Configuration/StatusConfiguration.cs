using Entity_Validator.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
                new Status() { StatusID = 1, StatusName = "Active" },
                new Status() { StatusID = 2, StatusName = "Closed" },
                new Status() { StatusID = 3, StatusName = "Approved" },
                new Status() { StatusID = 4, StatusName = "Unapproved" },
                new Status() { StatusID = 5, StatusName = "Paid" },
                new Status() { StatusID = 6, StatusName = "Unpaid" }
            );
        }
    }
}
