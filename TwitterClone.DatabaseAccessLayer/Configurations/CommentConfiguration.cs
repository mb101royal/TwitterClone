using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Core.Entities;

namespace TwitterClone.DatabaseAccessLayer.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasOne(t => t.ParentComment)
                .WithMany(t => t.Comments)
                .HasForeignKey(t => t.ParentCommentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
