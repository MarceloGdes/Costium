namespace Costium.Domain.ValueObjects;

public abstract class ValueObject
{
    //Define quais propriedades identificam o valor a ser comparado.
    protected abstract IEnumerable<object> GetEqualityComponents();

    //Implementação de Equals e GetHashCode baseada nas propriedades definidas em GetEqualityComponents.
    //Comparação padrão do .NET (que por padrão compara referência de memória). Passa a comprar os valores das propriedades
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType()) return false;
        return ((ValueObject)obj).GetEqualityComponents()
            .SequenceEqual(GetEqualityComponents());
    }

    //Combina os hash codes das propriedades para gerar um hash code único para o objeto.
    public override int GetHashCode() =>
         GetEqualityComponents()
            .Aggregate(1, (hash, obj) => HashCode.Combine(hash, obj));

    // Sobrecarga dos operadores de igualdade para facilitar a comparação entre objetos de valor.
    public static bool operator ==(ValueObject? a, ValueObject? b) =>
        a?.Equals(b) ?? b is null;

    public static bool operator !=(ValueObject? a, ValueObject? b) => !(a == b);
}
