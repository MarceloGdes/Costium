using Costium.Domain.Enums;

namespace Costium.Domain.Entities;

public class FinancialTransaction : BaseEntity
{
    public ExpenseInstallment ExpenseInstallment { get; private set; }
    public Guid ExpenseInstallmentId { get; private set; }
    public FinancialTransactionType Type { get; private set; }
    public double Amount { get; private set; }
    public DateTime TransactionDate { get; private set; }

    private FinancialTransaction(Guid ExpenseInstallmentId, FinancialTransactionType type, double amount, DateTime transactionDate)
    {
        ExpenseInstallmentId = ExpenseInstallmentId;
        Type = type;
        Amount = amount;
        TransactionDate = transactionDate;
    }
    public static FinancialTransaction Create(Guid ExpenseInstallmentId, FinancialTransactionType type, double amount, DateTime transactionDate)
    {
        return new FinancialTransaction(ExpenseInstallmentId, type, amount, transactionDate);
    }
}