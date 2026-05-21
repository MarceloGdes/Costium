namespace Costium.Application.DTOs.ExpenseTypes;

public class UpdateExpenseTypeDto
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
}
