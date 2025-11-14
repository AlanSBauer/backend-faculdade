namespace Application.DTOs;

// TODO: O grupo de DTO/Mapping deve avaliar se vai usar 'record', 'class' ou ambos.
// Incluir validações via FluentValidation (em outro grupo) e manter este DTO puro.
// Decidir se campos opcionais (ex: Estoque inicial) precisam de default.
// Adicionar comentários justificando escolhas no PR.

public record ProdutoCreateDto(
	string Nome,
	string Descricao,
	decimal Preco,
	int Estoque
);
