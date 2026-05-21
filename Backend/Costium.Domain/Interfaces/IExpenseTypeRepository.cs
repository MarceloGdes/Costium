using Costium.Domain.Enums;

namespace Costium.Domain.Interfaces;

public interface IExpenseTypeRepository
{
    Task<ExpenseType?> GetByIdAsync(Guid id);
    Task<IEnumerable<ExpenseType>> GetAllAsync();
    Task<ExpenseType> AddAsync(ExpenseType expenseType);
    Task UpdateAsync(ExpenseType expenseType);
    Task DeleteAsync(ExpenseType expenseType);
}
