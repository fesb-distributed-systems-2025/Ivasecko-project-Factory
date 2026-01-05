using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            // Primary key
            builder.HasKey(e => e.Id);

            // Properties
            builder.Property(e => e.Subject)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Message)
                   .HasMaxLength(2000);

            // Sender relation (Worker -> Email)
            builder.HasOne(e => e.Sender)
                   .WithMany(w => w.SentEmails)
                   .HasForeignKey(e => e.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Receiver relation (Worker -> Email)
            builder.HasOne(e => e.Receiver)
                   .WithMany(w => w.ReceivedEmails)
                   .HasForeignKey(e => e.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
