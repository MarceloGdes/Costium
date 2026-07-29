namespace Costium.Application.DTOs.ExpenseCategory;

public record ExpenseCategoryResponse(
    Guid Id,
    string Description,
    DateTime CreatedAt
);
