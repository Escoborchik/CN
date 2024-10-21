using Coach.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coach.DAL.Configurations
{
    public class SportsmenConfiguration : IEntityTypeConfiguration<SportsmenEntity>
    {
        public void Configure(EntityTypeBuilder<SportsmenEntity> builder)
        {
          
        }
    }
}
