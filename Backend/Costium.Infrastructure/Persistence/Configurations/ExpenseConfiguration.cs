using Costium.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costium.Infrastructure.Persistence.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(e => e.Id);

        //Preenche automaticamente o campo Number com o próximo valor da sequência configurada
        builder.Property(e => e.Number)
            .HasDefaultValueSql("NEXT VALUE FOR ExpenseNumberSequence");

        builder.Property(e => e.Description)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.ExpenseType)
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne(e => e.ExpenseCategory)
            .WithMany()
            .HasForeignKey(e => e.ExpenseCategoryId)
            .IsRequired();

        builder


    }
}
