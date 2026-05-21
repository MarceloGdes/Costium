using Costium.Domain.Enums;
using Costium.Domain.Value_Objects;

namespace Costium.Domain.Entities;

public class FinancialTransaction : BaseEntity
{
    public ExpenseInstallment ExpenseInstallment { get; private set; }
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
    public static FinancialTransaction Create(Guid ExpenseInstallmentId, FinancialTransactionType type, Money amount, DateTime transactionDate)
    {
        return new FinancialTransaction(ExpenseInstallmentId, type, amount, transactionDate);
    }
}