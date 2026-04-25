# 🍔 Good Hamburger API

API REST para gerenciamento de pedidos da lanchonete Good Hamburger.

## Tecnologias

- .NET 8 / ASP.NET Core
- Entity Framework Core + MySQL
- MediatR, FluentValidation

## Como Executar

Configure a connection string no `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=GoodHamburger;User=root;Password=suasenha;AllowPublicKeyRetrieval=true;SslMode=None;"
}
```

```bash
# Clone o repositório
git clone https://github.com/theopin1/GoodHamburguer.git
cd GoodHamburguer

# Aplique as migrations
dotnet ef database update --project GoodHamburger.Infra --startup-project GoodHamburger

# Execute
dotnet run --project GoodHamburger
```

Acesse a documentação em `https://localhost:7000/swagger`.

## Arquitetura

O projeto foi desenvolvido seguindo o padrão **CQRS (Command Query Responsibility Segregation)**, separando as operações de leitura (Queries) das operações de escrita (Commands).

### Estrutura de Camadas

```
GoodHamburger/
├── GoodHamburger.API          # Controllers e configuração da aplicação
├── GoodHamburger.Application  # Commands, Queries, Handlers, Validators e DTOs
└── GoodHamburger.Infra        # Entidades, DbContext e Migrations
```

### Decisões Técnicas

**CQRS com MediatR**
Separação clara entre Commands (escrita) e Queries (leitura), com Handlers dedicados para cada operação. Essa abordagem facilita a manutenção, o isolamento de responsabilidades e a criação de testes automatizados no futuro.

**FluentValidation**
Validators separados dos Handlers para manter a validação de entrada desacoplada da regra de negócio. Cada Command possui seu próprio Validator, facilitando a extensão e manutenção das validações.

**Tabelas para Sanduíches e Acompanhamentos**
Em vez de usar enums fixos no código, optou-se por persistir sanduíches e acompanhamentos no banco de dados. Isso permite expansão futura do cardápio sem necessidade de alteração no código.

**Relacionamento Many-to-Many**
A relação entre Pedidos e Acompanhamentos foi modelada como many-to-many, com tabela intermediária gerenciada automaticamente pelo Entity Framework Core.

## ⚠️ O que ficou fora

- Testes automatizados das regras de negócio
- Frontend em Blazor
- Autenticação e autorização
- Paginação na listagem de pedidos
- Seed automático do cardápio no banco de dados
