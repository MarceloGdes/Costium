using Costium.Domain.Enums;
using Costium.Domain.Value_Objects;

namespace Costium.Domain.Entities;

public class Expense : BaseEntity
{
    public int ExpenseIdNumber{ get; private set; }
    public string? Description { get; private set; }
    public Money TotalAmount { get; private set; }
    public int InstallmentCount { get; private set; }
    public ExpenseType ExpenseType { get; private set; }
    public ExpenseCategory ExpenseCategory { get; private set; }
    public Guid ExpenseCategoryId { get; private set; }

    private readonly List<ExpenseInstallment> _installments;
    public IReadOnlyCollection<ExpenseInstallment> Installments => _installments;

}
