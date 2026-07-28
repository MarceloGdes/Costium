using Costium.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costium.Infrastructure.Persistence.Configurations;

public class FinancialTransactionConfiguration : BaseEntityConfiguration<FinancialTransaction>
{
    public override void Configure(EntityTypeBuilder<FinancialTransaction> builder)
    {
        builder.ToTable("FinancialTransactions");

        builder.HasKey(ft => ft.Id);

        builder.HasOne(ft => ft.ExpenseInstallment)
            .WithMany(ei => ei.FinancialTransactions)
            .HasForeignKey(ft => ft.ExpenseInstallmentId)
            .OnDelete(DeleteBehavior.Restrict); // Faz com que a exclusão de um ExpenseInstallment não exclua os FinancialTransactions associados

        builder.Property(ft => ft.Type)
            .HasConversion<string>()
            .IsRequired();

        builder.OwnsMoney(ft => ft.Amount);

        builder.Property(ft => ft.TransactionDate)
            .IsRequired();

        builder.HasIndex(ft => ft.ExpenseInstallmentId);
    }
}
