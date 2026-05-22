using Costium.Domain.Enums;
using Costium.Domain.Exceptions;
using Costium.Domain.ValueObjects;

namespace Costium.Domain.Entities;

public class FinancialTransaction : BaseEntity
{
    public ExpenseInstallment? ExpenseInstallment { get; private set; }
    public Guid ExpenseInstallmentId { get; private set; }
    public FinancialTransactionType Type { get; private set; }
    public Money Amount { get; private set; }
    public DateTime TransactionDate { get; private set; }

    private FinancialTransaction(Guid expenseInstallmentId, FinancialTransactionType type, Money amount, DateTime transactionDate)
    {
        ExpenseInstallmentId = expenseInstallmentId;
        Type = type;
        Amount = amount;
        TransactionDate = transactionDate;
    }
    public static FinancialTransaction Create(Guid expenseInstallmentId, FinancialTransactionType type, Money amount, DateTime transactionDate)
    {
        if(expenseInstallmentId == Guid.Empty)
            throw new DomainException("Parcela é obrigatória.");

        if(amount.Amount <= 0)
            throw new DomainException("Valor deve ser maior que zero.");

        if(transactionDate > DateTime.UtcNow)
            throw new DomainException("Data da transação não pode ser futura.");

        return new FinancialTransaction(expenseInstallmentId, type, amount, transactionDate);
    }
}