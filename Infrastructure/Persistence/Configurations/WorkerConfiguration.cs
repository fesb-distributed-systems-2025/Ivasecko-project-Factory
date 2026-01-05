using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            // Primary key
            builder.HasKey(w => w.Id);

            // Properties
            builder.Property(w => w.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // 1-N relation: Worker -> Sent Emails
            builder.HasMany(w => w.SentEmails)
                   .WithOne(e => e.Sender)
                   .HasForeignKey(e => e.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 1-N relation: Worker -> Received Emails
            builder.HasMany(w => w.ReceivedEmails)
                   .WithOne(e => e.Receiver)
                   .HasForeignKey(e => e.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
