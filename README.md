# 🍔 Good Hamburger API

API REST para gerenciamento de pedidos da lanchonete Good Hamburger, construída com .NET 8 e ASP.NET Core.

## 📋 Cardápio

### Sanduíches
| Item | Preço |
|------|-------|
| X Burger | R$ 5,00 |
| X Egg | R$ 4,50 |
| X Bacon | R$ 7,00 |

### Acompanhamentos
| Item | Preço |
|------|-------|
| Batata Frita | R$ 2,00 |
| Refrigerante | R$ 2,50 |

### Regras de Desconto
| Combinação | Desconto |
|------------|----------|
| Sanduíche + Batata Frita + Refrigerante | 20% |
| Sanduíche + Refrigerante | 15% |
| Sanduíche + Batata Frita | 10% |

## 🚀 Como Executar

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL](https://dev.mysql.com/downloads/mysql/)

### Configuração do Banco de Dados

Configure a connection string no `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=GoodHamburger;User=root;Password=suasenha;AllowPublicKeyRetrieval=true;SslMode=None;"
}
```

### Rodando o Projeto

```bash
# Clone o repositório
git clone https://github.com/theopin1/GoodHamburguer.git
cd GoodHamburguer

# Aplique as migrations
dotnet ef database update --project GoodHamburger.Infra --startup-project GoodHamburger

# Execute a API
dotnet run --project GoodHamburger
```

A API estará disponível em `https://localhost:7000` e a documentação Swagger em `https://localhost:7000/swagger`.

## 📡 Endpoints

### Cardápio
| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/cardapio` | Lista sanduíches e acompanhamentos disponíveis |

### Pedidos
| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/pedido` | Lista todos os pedidos |
| GET | `/api/pedido/{id}` | Busca pedido por ID |
| POST | `/api/pedido` | Cria novo pedido |
| PUT | `/api/pedido/{id}` | Atualiza pedido existente |
| DELETE | `/api/pedido/{id}` | Remove pedido |

### Exemplo de Requisição

```json
POST /api/pedido
{
  "sanduicheId": 1,
  "acompanhamentosIds": [1, 2],
  "observacao": "sem cebola"
}
```

### Exemplo de Resposta

```json
{
  "id": 1,
  "sanduiche": {
    "id": 1,
    "nome": "X Burger",
    "valor": 5.00
  },
  "acompanhamentos": [
    { "id": 1, "nome": "Batata Frita", "valor": 2.00 },
    { "id": 2, "nome": "Refrigerante", "valor": 2.50 }
  ],
  "observacao": "sem cebola",
  "valor": 9.50,
  "valorComDesconto": 7.60
}
```

## 🏗️ Arquitetura

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

**Pomelo EF Core + MySQL**
Utilizado como ORM principal, com Pomelo como provider para MySQL, permitindo o uso de migrations e mapeamento automático dos relacionamentos.

## ⚠️ O que ficou fora

- Testes automatizados das regras de negócio
- Frontend em Blazor
- Autenticação e autorização
- Paginação na listagem de pedidos
- Seed automático do cardápio no banco de dados

## 🛠️ Tecnologias

- .NET 8
- ASP.NET Core
- Entity Framework Core
- Pomelo.EntityFrameworkCore.MySql
- MediatR
- FluentValidation
- Swagger / Swashbuckle
- MySQL
