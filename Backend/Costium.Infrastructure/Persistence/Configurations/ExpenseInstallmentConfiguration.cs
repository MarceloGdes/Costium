using Costium.Domain.Entities;
using Costium.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costium.Infrastructure.Persistence.Configurations;

public class ExpenseInstallmentConfiguration : BaseEntityConfiguration<ExpenseInstallment>
{
    public override void Configure(EntityTypeBuilder<ExpenseInstallment> builder)
    {
        builder.ToTable("ExpenseInstallments");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.InstallmentNumber)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.OwnsMoney(e => e.Amount);

        builder.Property(e => e.DueDate)
            .IsRequired();

        builder.HasMany(e => e.FinancialTransactions)
            .WithOne()
            .HasForeignKey(ft => ft.ExpenseInstallmentId)
            .IsRequired();
    }
}
