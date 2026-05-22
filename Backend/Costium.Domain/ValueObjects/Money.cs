using Costium.Domain.Enums;
using Costium.Domain.Exceptions;

namespace Costium.Domain.ValueObjects;

public sealed class Money : ValueObject
{
    public double Amount { get; private set; }
    public Currency Currency { get; private set; }

    private Money(double amount, Currency currency) 
    {
        Amount = amount;
        Currency = currency;
    }
    public static Money Create(double amount, Currency currency)
    {
        if (amount < 0)
            throw new DomainException("Valor não pode ser negativo.");

        return new Money(amount, currency);
    }
    public Money Add(Money other)
    {
        if (Currency != other.Currency)
            throw new DomainException("Não é possível somar valores de moedas diferentes.");

        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        if (Currency != other.Currency)
            throw new DomainException("Não é possível subtrair valores de moedas diferentes.");

        if (Amount < other.Amount)
            throw new DomainException("Resultado da subtração não pode ser negativo.");

        return new Money(Amount - other.Amount, Currency);
    }

    // Implementação de Equals e GetHashCode é herdada de ValueObject
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
