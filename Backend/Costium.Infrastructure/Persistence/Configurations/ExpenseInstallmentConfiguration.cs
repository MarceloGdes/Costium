using Costium.Domain.Entities;
using Costium.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costium.Infrastructure.Persistence.Configurations;

public class ExpenseInstallmentConfiguration : IEntityTypeConfiguration<ExpenseInstallment>
{
    public void Configure(EntityTypeBuilder<ExpenseInstallment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.InstallmentNumber)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.OwnsOne(e => e.Amount, money =>
        {
            money.Property(m => m.Amount)
                .HasColumnName("Amount")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            money.Property(m => m.Currency)
                .HasColumnName("Currency")
                .HasMaxLength(3)
                .IsRequired();
        });

        builder.Property(e => e.DueDate)
            .IsRequired();

        builder.HasMany(e => e.FinancialTransactions)
            .WithOne()
            .HasForeignKey(ft => ft.ExpenseInstallmentId)
            .IsRequired();
    }
}
