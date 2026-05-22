using Costium.Domain.Enums;
using Costium.Domain.Exceptions;
using Costium.Domain.ValueObjects;
namespace Costium.Domain.Entities;

public class ExpenseInstallment : BaseEntity
{
    public Guid ExpenseId { get; private set; }
    public int InstallmentNumber { get; private set; }
    public InstallmentStatus Status { get; private set; }
    public Money Amount { get; private set; }
    public DateTime DueDate { get; private set; }

    private readonly List<FinancialTransaction> _financialTransactions;
    public IReadOnlyCollection<FinancialTransaction> FinancialTransactions => _financialTransactions;

    private ExpenseInstallment(Guid expenseId, int installmentNumber, InstallmentStatus status, Money amount, DateTime dueDate)
    {
        ExpenseId = expenseId;
        InstallmentNumber = installmentNumber;
        Status = status;
        Amount = amount;
        DueDate = dueDate;
        _financialTransactions = [];
    }

    public static ExpenseInstallment Create(Guid expenseId, int installmentNumber, Money amount, DateTime dueDate)
    {
        if (expenseId == Guid.Empty)
            throw new DomainException("Despesa é obrigatória.");
        if (installmentNumber <= 0)
            throw new DomainException("Número da parcela deve ser maior que zero.");
        if (amount.Amount <= 0)
            throw new DomainException("Valor da parcela deve ser maior que zero.");

        return new ExpenseInstallment(expenseId, installmentNumber, InstallmentStatus.Pending, amount, dueDate);
    }
}
