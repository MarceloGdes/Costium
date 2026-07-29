using Costium.Domain.Entities;

namespace Costium.Domain.Respositories;

public interface IExpenseCategoryRepository
{
    Task<ExpenseCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistsWithDescriptionAsync(string description, CancellationToken cancellationToken);
    void Add(ExpenseCategory expenseCategory);
}
