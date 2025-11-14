# Grupo Service

Objetivo: Centralizar regras de negócio e orquestração entre Repository, Factory, validação e mapeamento.

## Tarefas
1. Implementar métodos de `ProdutoService`:
   - `ListarAsync`
   - `ObterAsync`
   - `CriarAsync`
   - `RemoverAsync`
2. Usar apenas abstrações (IProdutoRepository, ProdutoFactory).
3. Adicionar validações adicionais se fizer sentido (ex: tamanho mínimo do nome) – mas preferir deixá-las para FluentValidation (outro grupo) e manter aqui somente invariantes.
4. Decidir estratégia de erro: exceções, retorno nulo, ou Result Pattern (se usar, documentar).

## Regras Mínimas Sugeridas
- Nome não vazio / trimmed.
- Preço > 0.
- Estoque >= 0.

## Não Fazer
- Não acessar diretamente DbContext.
- Não retornar entidades mutáveis para fora se já houver DTO integrado (coordenar com grupo DTO).

## Entrega
- Branch: `feature/service`
- README (este) pode ser atualizado com decisões.
- (Opcional) Teste unitário simulando repository (mock ou fake in-memory).
