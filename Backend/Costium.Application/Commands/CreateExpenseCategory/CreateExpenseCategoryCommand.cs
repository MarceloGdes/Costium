using Costium.Application.DTOs.ExpenseCategory;
using MediatR;

namespace Costium.Application.Commands.CreateExpenseCategory;

public record CreateExpenseCategoryCommand(string Description)
    : IRequest<ExpenseCategoryResponse>;
