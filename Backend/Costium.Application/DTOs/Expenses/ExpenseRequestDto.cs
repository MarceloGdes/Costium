namespace Costium.Application.DTOs.Expenses;

public class ExpenseRequestDto
{
    public string Description { get; set; } = string.Empty;
    public double TotalValue { get; set; }
    public bool Paid { get; set; }
    public Guid ExpenseTypeId { get; set; }
    public List<Guid> ClassificationIds { get; set; } = new();
    public List<ExpenseInstallmentDto> Installments { get; set; } = new();
}
