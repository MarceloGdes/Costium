using Costium.Domain.Entities;

namespace Costium.Domain.Interfaces;

public interface IExpenseInstallmentRepository
{
    Task<ExpenseInstallment?> GetByIdAsync(Guid id);
    Task<IEnumerable<ExpenseInstallment>> GetAllAsync();
    Task<IEnumerable<ExpenseInstallment>> AddRangeAsync(IEnumerable<ExpenseInstallment> installments);
    Task<ExpenseInstallment> AddAsync(ExpenseInstallment installment);
    Task UpdateAsync(ExpenseInstallment installment);
    Task DeleteAsync(ExpenseInstallment installment);
}
