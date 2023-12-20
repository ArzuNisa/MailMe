
using MailMeEntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MailMeDataAccessLayer.Configurations
{
    public class MailUserConfiguration : IEntityTypeConfiguration<MailUser>
    {
        public void Configure(EntityTypeBuilder<MailUser> builder)
        {
            builder.HasOne(mu => mu.AppUser)
                .WithMany(au => au.MailUsers)
                .HasForeignKey(mu => mu.AppUserId);
            builder.ToTable("MailUsers");
        }
    }
}
