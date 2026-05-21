using Costium.Domain.Enums;
using Costium.Domain.Exceptions;
using Costium.Domain.Value_Objects;

namespace Costium.Domain.Entities;

public class ExpenseInstallment : BaseEntity
{
    private Guid ExpenseId { get; }
    private int InstallmentNumber { get; }
    private InstallmentStatus Status { get; }
    private Money Amount { get; }
    private DateTime DueDate { get; }

    private readonly List<FinancialTransaction> _financialTransactions;
    public IReadOnlyCollection<FinancialTransaction> FinancialTransactions => _financialTransactions;

    private ExpenseInstallment(Guid expenseId, int installmentNumber, InstallmentStatus status, Money amount, DateTime dueDate, List<FinancialTransaction> financialTransactions)
    {
        ExpenseId = expenseId;
        InstallmentNumber = installmentNumber;
        Status = status;
        Amount = amount;
        DueDate = dueDate;
        _financialTransactions = financialTransactions;
    }

    public static ExpenseInstallment Create(Guid expenseId, int installmentNumber, Money amount, DateTime dueDate)
    {
        if (expenseId == Guid.Empty)
            throw new DomainException("Despesa é obrigatória.");
        if (installmentNumber <= 0)
            throw new DomainException("Número da parcela deve ser maior que zero.");
        if (amount.Amount <= 0)
            throw new DomainException("Valor da parcela deve ser maior que zero.");

        return new ExpenseInstallment(expenseId, installmentNumber, InstallmentStatus.Pending, amount, dueDate, []);
    }
}
