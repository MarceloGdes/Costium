namespace Costium.Application.DTOs.Expenses;

public class ExpenseInstallmentDto
{
    public int InstallmentNumber { get; set; }
    public double Value { get; set; }
    public DateTime DueDate { get; set; }
    public bool Paid { get; set; }
}
