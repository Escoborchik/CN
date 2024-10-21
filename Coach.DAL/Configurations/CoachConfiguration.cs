using Coach.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coach.DAL.Configurations
{
    public class CoachConfiguration : IEntityTypeConfiguration<CoachEntity>
    {
        public void Configure(EntityTypeBuilder<CoachEntity> builder)
        {
            
        }
    }
}
