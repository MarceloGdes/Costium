# CLAUDE.md

Este arquivo fornece orientações ao Claude Code (claude.ai/code) ao trabalhar com código neste repositório.

## Visão Geral do Projeto

Costium é uma solução .NET 8 com arquitetura Clean Architecture contendo 4 projetos:
- **Costium.Api** - API Web ASP.NET Core (ponto de entrada)
- **Costium.Application** - Camada de aplicação com DTOs
- **Costium.Domain** - Camada de domínio com entidades, value objects, enums, exceções
- **Costium.Infrastructure** - Camada de infraestrutura com persistência EF Core (SQL Server)

## Comandos

### Build
```bash
dotnet build Costium.slnx
```

### Executar API
```bash
dotnet run --project Costium.Api
```

### Executar Testes
```bash
dotnet test
```

### Executar Teste Único
```bash
dotnet test --filter "FullyQualifiedName~NomeDoTeste"
```

### Build de Projeto Específico
```bash
dotnet build Costium.Api/Costium.Api.csproj
dotnet build Costium.Application/Costium.Application.csproj
dotnet build Costium.Domain/Costium.Domain.csproj
dotnet build Costium.Infrastructure/Costium.Infrastructure.csproj
```

## Arquitetura

### Dependências dos Projetos
```
Costium.Api → Costium.Application → Costium.Domain
                ↓
         Costium.Infrastructure → Costium.Domain
```

### Camada de Domínio (`Costium.Domain`)
- **Entidades**: `Expense`, `ExpenseCategory`, `ExpenseInstallment`, `FinancialTransaction`, `User`, `BaseEntity`
- **Value Objects**: `Money` (valor + moeda), `ValueObject` (classe base)
- **Enums**: `ExpenseType`, `ExpenseCategory`, `InstallmentStatus`, `FinancialTransactionType`, `Currency`
- **Exceções**: `DomainException`

Principais Regras de Domínio:
- `Expense` requer descrição (máx 255 chars), categoria e pelo menos uma parcela
- `Expense` tem `Number` sequencial gerado via sequence SQL `ExpenseNumberSequence`
- `Expense.TotalAmount` calculado das parcelas (ignora a primeira parcela - aparente bug nas linhas 17-22 do Expense.cs)
- `ExpenseInstallment` requer ID da despesa, número da parcela > 0, valor > 0, cria com status `Pending`
- `ExpenseInstallment` tem coleção de `FinancialTransaction`

### Camada de Aplicação (`Costium.Application`)
- **DTOs**: `ExpenseRequestDto`, `ExpenseInstallmentDto`, `CreateExpenseTypeDto`, `UpdateExpenseTypeDto`

### Camada de Infraestrutura (`Costium.Infrastructure`)
- **EF Core** com SQL Server (v9.0.17)
- **DbContext**: `AppDbContext` com DbSets para todas as entidades
- **Configurações**: `ExpenseConfiguration`, `ExpenseCategoryConfiguration`, `ExpenseInstallmentConfiguration` usando `IEntityTypeConfiguration`
- **Sequence**: `ExpenseNumberSequence` para auto-gerar `Expense.Number`

### Camada de API (`Costium.Api`)
- API Web ASP.NET Core minimal com Swagger/OpenAPI (Swashbuckle)
- Controllers, Program.cs com configuração de DI
- Nenhum controller implementado além do WeatherForecastController (template)

## Detalhes Importantes do Domínio

### Value Object: Money (ValueObjects/Money.cs)
- Value object imutável com `Amount` (decimal) e `Currency` (enum Currency)
- Implementa igualdade via classe base `ValueObject`
- Tem método `Add(Money other)` para adição segura de moeda

### Entidade: Expense (Entities/Expense.cs)
- `Number` sequencial auto-gerado via sequence SQL
- `TotalAmount` propriedade computada - **Nota: ignora primeira parcela (Skip(1)) - provável bug**
- Factory method `Create()` com validações

### Entidade: ExpenseInstallment (Entities/ExpenseInstallment.cs)
- Factory method `Create()` com validações
- Coleção de `FinancialTransaction` (setter privado, exposto como IReadOnlyCollection)

## Observações de Desenvolvimento

- **Sem arquivo de solução (.sln)** - usa `.slnx` (VS Solution Filter)
- **Sem projetos de teste** encontrados na solução
- **Nenhum controller implementado** ainda na API (apenas template WeatherForecastController)
- **Migrations do EF Core** ainda não criadas
- **Connection string** configurada em `appsettings.json` / `appsettings.Development.json`
- Usa **nullable reference types** e **implicit usings** (habilitados em todos projetos)
- **EF Core 9.0.17** com provider SQL Server
- **Swashbuckle.AspNetCore 6.6.2** para Swagger/OpenAPI