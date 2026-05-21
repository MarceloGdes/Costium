using Costium.Domain.Entities;

namespace Costium.Domain.Interfaces;

public interface IExpenseClassificationMappingRepository
{
    Task<IEnumerable<ExpenseClassificationMapping>> GetByExpenseIdAsync(Guid expenseId);
    Task<ExpenseClassificationMapping> AddAsync(ExpenseClassificationMapping mapping);
    Task<IEnumerable<ExpenseClassificationMapping>> AddRangeAsync(IEnumerable<ExpenseClassificationMapping> mappings);
    Task DeleteAsync(ExpenseClassificationMapping mapping);
}
