using Costium.Domain.Exceptions;

namespace Costium.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }

    private User(string name)
    {
        Name = name;
    }

    public static User Create(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new DomainException("O nome do usuário é obrigatório");

        return new User(name);
    }
}
