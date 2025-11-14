# Grupo Factory

Objetivo: Garantir criação consistente de `Produto` encapsulando invariantes e evitando duplicação de regras em vários pontos.

## Tarefas
1. Implementar `ProdutoFactory.Criar(nome, descricao, preco, estoque)`.
2. Validar invariantes (nome, descricao, preco > 0, estoque >= 0, trimming de strings).
3. Decidir forma de sinalizar erro: exceções específicas, `ArgumentException`, ou retorno de um tipo Result.
4. Discutir se Factory ainda faz sentido quando Service já aplica parte das regras (explicar no PR para demonstrar reflexão crítica).

## Boas Práticas
- Não fazer persistência aqui.
- Mantê-la pura (sem acessar DI ou serviço externo).
- Retornar entidade pronta para ser persistida.

## Extensões Possíveis (não obrigatórias)
- Adicionar cálculo ou normalização adicional (ex: Nome em Title Case).
- Criar sobrecarga para defaults (ex: estoque inicial = 0).

## Entrega
- Branch: `feature/factory`.
- Explicar em comentário final: Quando uma Factory seria overengineering?
