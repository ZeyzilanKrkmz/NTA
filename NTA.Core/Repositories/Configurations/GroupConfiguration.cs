using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTA.Core.Models;

namespace NTA.Core.Repositories.Configurations;

public class GroupConfiguration
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.Status).HasDefaultValue(true);
        builder.HasQueryFilter(x => x.Status);
    }
}