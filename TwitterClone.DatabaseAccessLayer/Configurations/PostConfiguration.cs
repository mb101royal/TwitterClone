using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Entities;

namespace TwitterClone.DatabaseAccessLayer.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(t => t.Content)
                .IsRequired()
                .HasMaxLength(512);
            builder.Property(t => t.TimesUpdated)
                .HasDefaultValue(0);
            builder.HasOne(t => t.AppUser)
                .WithMany(t => t.Blogs)
                .HasForeignKey(t => t.AppUserId);
        }
    }
}
