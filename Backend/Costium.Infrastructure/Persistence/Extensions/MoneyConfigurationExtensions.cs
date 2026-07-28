using System.Linq.Expressions;
using Costium.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Costium.Infrastructure.Persistence.Configurations;

public static class MoneyConfigurationExtensions
{
    // 
    public static void OwnsMoney<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, Money>> propertyExpression,
        string amountColumnName = "Amount",
        string currencyColumnName = "Currency") where T : class
    {
        builder.OwnsOne(propertyExpression, money =>
        {
            money.Property(m => m.Amount)
                .HasColumnName(amountColumnName)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            money.Property(m => m.Currency)
                .HasColumnName(currencyColumnName)
                .HasMaxLength(3)
                .IsRequired();
        });
    }
}