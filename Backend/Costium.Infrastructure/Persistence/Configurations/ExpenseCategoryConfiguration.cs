using Costium.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costium.Infrastructure.Persistence.Configurations;

public class ExpenseCategoryConfiguration : BaseEntityConfiguration<ExpenseCategory>
{
    public override void Configure(EntityTypeBuilder<ExpenseCategory> builder)
    {
        builder.ToTable("ExpenseCategories");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description)
            .HasMaxLength(50)
            .IsRequired();
    }
}