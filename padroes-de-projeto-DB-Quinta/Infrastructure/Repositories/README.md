# Grupo Repository

Objetivo: Implementar o Repository Pattern para a entidade `Produto`.

## Tarefas
1. Criar a classe `ProdutoRepository` que implementa `IProdutoRepository`.
2. Usar `AppDbContext` via injeção de dependência.
3. Métodos mínimos:
   - `GetAllAsync` (usar `AsNoTracking()`)
   - `GetByIdAsync`
   - `AddAsync`
   - `RemoveAsync`
   - `SaveChangesAsync`
4. Não adicionar regras de negócio aqui (apenas persistência). Regras ficam no Service / Factory.
5. Justificar no final do arquivo (seção) quando seria aceitável NÃO usar repository (ex: projeto pequeno, EF Core já abstrai bastante).

## Dicas
- Use `FindAsync` para busca por id.
- Não exponha o `DbContext` para fora.
- Evite retornar `IQueryable` para não vazar a infraestrutura.

## Entrega
- Criar branch: `feature/repository`.
- Adicionar testes (opcional + bônus) usando `UseInMemoryDatabase`.
- Atualizar `Program.cs` registrando: `builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();`.

## Quando NÃO usar
Explique aqui no PR: por que em APIs simples minimalistas pode ser overengineering.
