# Estrutura do Projeto – Explicação Didática

Este documento descreve a organização de pastas da API e o motivo de cada escolha, visando boas práticas de separação de responsabilidades.

## Visão em Camadas
```
Presentation (Program.cs / Endpoints)
        ↓
Application (Serviços, DTOs, Interfaces)
        ↓
Domain (Entidades, Regras puras)
        ↓
Infrastructure (Persistência, Implementações técnicas)
```
A dependência sempre aponta “para baixo” em direção a regras mais puras. Nada no Domain deve depender de Infrastructure.

## Pastas Principais

### `Domain/Entities`
Contém as entidades centrais do negócio. Ex.: `Produto`. 
Características:
- Contém apenas dados e invariantes simples.
- Não referencia EF Core diretamente (exceto DataAnnotations básicas, que podem ser removidas futuramente em favor de Fluent API se quisermos deixar o domínio totalmente limpo).

Possíveis evoluções:
- `Domain/ValueObjects` para tipos imutáveis (ex: `Dinheiro`).
- `Domain/Events` para Domain Events.
- `Domain/Specifications` para regras de filtragem combináveis.

### `Application/Interfaces`
Define contratos (ex: `IProdutoRepository`, `IProdutoService`).
Objetivo: permitir que o restante da aplicação consuma abstrações sem conhecer detalhes de implementação.

### `Application/Services`
Orquestra casos de uso (ex: criar produto, listar produtos). 
Inclui também utilitários de aplicação como `MappingExtensions` e a `ProdutoFactory` (colocada aqui didaticamente; poderia morar em Domain se encapsular invariantes complexas).

### `Application/DTOs`
Define modelos de entrada e saída (DTOs) isolando o domínio da camada externa (JSON/API). Evita vazar mudanças internas das entidades para o contrato público.

### `Infrastructure/Persistence`
Implementações técnicas de persistência, como `AppDbContext` (EF Core) e futuras configurações de mapeamento. Aqui ficam detalhes acoplados a ferramentas externas.

### `Infrastructure/Repositories`
Implementações concretas das interfaces de repositório. Ex.: `ProdutoRepository` (skeleton). Não contém regra de negócio, apenas acesso a dados.

### `Migrations/`
Gerado pelo EF Core, representa a evolução do schema do banco. Faz parte da infraestrutura e pode ser movido para dentro de `Infrastructure/Persistence` futuramente.

### `docs/`
Documentação de apoio para alunos e contribuidores. Ex.: este arquivo.

## Fluxo de Dependência (Exemplo Futuro Completo)
```
Program.cs → IProdutoService → ProdutoService → IProdutoRepository → ProdutoRepository → AppDbContext
                               ↓
                           ProdutoFactory → Produto (Domain)
                              ↑
                         ProdutoCreateDto (entrada)
```

## Padrões já introduzidos ou preparados
| Padrão | Local | Status |
|--------|-------|--------|
| Repository | Application/Interfaces + Infrastructure/Repositories | Skeleton |
| Service | Application/Interfaces + Application/Services | Skeleton |
| Factory | Application/Services | Skeleton |
| DTO / Mapper | Application/DTOs + Application/Services | Skeleton |
| Validation (planejado) | Application/Validation (a criar) | Não iniciado |

## Decisões Didáticas
1. `ProdutoFactory` ficou em Application para que os alunos visualizem facilmente sua interação com o Service. Em um design mais “Domain Driven”, poderia mover para `Domain/Factories`.
2. DataAnnotations ainda estão na entidade para facilitar prototipagem; podem ser substituídas por FluentValidation + Fluent API no futuro.
3. Mapping manual preferido inicialmente para reforçar entendimento antes de automação (AutoMapper).
4. Minimal API (`Program.cs`) concentra endpoints agora; pode ser refatorado em módulos (`Presentation/Endpoints/ProdutosEndpoints.cs`).

## Recomendações Futuras
- Introduzir testes: criar projeto `APIProdutos.Tests`.
- Adicionar middleware de tratamento de erros retornando Problem Details (RFC 7807).
- Logging estruturado (Serilog) com Correlation Id.
- Implementar caches (Decorator Pattern sobre o Service).
- Specification Pattern para filtros complexos de produtos.

## Checklist de Conformidade de Camadas
| Item | OK quando… |
|------|------------|
| Domain não depende de Application/Infrastructure | Não há `using Infrastructure` no Domain |
| Application não depende de implementações concretas | Usa apenas interfaces |
| Infrastructure depende de Application | Implementa interfaces definidas lá |
| Presentation não faz acesso direto ao DbContext | Usa Services / DTOs |

## Perguntas de Reflexão
- Este tamanho de projeto justifica todos os padrões? Em quais cenários você removeria alguns?
- A Factory agrega valor real aqui ou só repete validações que poderiam estar no Service?
- Quando valeria migrar para CQRS?

## Resumo Final
A estrutura busca equilíbrio entre clareza pedagógica e escalabilidade futura. Alunos devem focar em entender o PORQUÊ de cada camada antes de adicionar mais complexidade.
