using Costium.Domain.Entities;

namespace Costium.Domain.Interfaces;

public interface IExpenseClassificationRepository
{
    Task<ExpenseClassification?> GetByIdAsync(Guid id);
    Task<IEnumerable<ExpenseClassification>> GetAllAsync();
    Task<ExpenseClassification> AddAsync(ExpenseClassification classification);
    Task UpdateAsync(ExpenseClassification classification);
    Task DeleteAsync(ExpenseClassification classification);
}
