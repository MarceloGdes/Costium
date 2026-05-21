using Costium.Domain.Enums;
using Costium.Domain.Value_Objects;

namespace Costium.Domain.Entities;

public class ExpenseInstallment : BaseEntity
{
    public Guid ExpenseId { get; private set; }
    public Expense Expense { get; private set; }
    public int InstallmentNumber { get; private set; }
    public InstallmentStatus Status { get; private set; }
    public Money Amount { get; private set; }
    public DateTime DueDate { get; private set; }

    private readonly List<FinancialTransaction> _financialTransactions;
    public IReadOnlyCollection<FinancialTransaction> FinancialTransactions => _financialTransactions;
}
