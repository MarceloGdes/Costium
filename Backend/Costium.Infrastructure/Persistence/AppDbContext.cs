using Costium.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Costium.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    public DbSet<ExpenseInstallment> ExpenseInstallments { get; set; }
    public DbSet<FinancialTransaction> FinancialTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Configura a sequência para o campo Number da entidade Expense
        modelBuilder.HasSequence<int>("ExpenseNumberSequence")
            .StartsAt(1)
            .IncrementsBy(1);
    }
}
