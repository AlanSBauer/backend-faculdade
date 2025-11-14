# Trabalho em Grupo (API de Produtos)

Este repositório está preparado para o trabalho em grupo. A base é uma API minimalista em ASP.NET Core + EF Core. Os grupos devem evoluir a arquitetura aplicando padrões selecionados.

## Objetivos
- Separar responsabilidades (persistência, regras de negócio, exposição).
- Aplicar padrões básicos de forma crítica (quando usar / quando não usar).
- Preparar terreno para fases futuras (logging, CQRS, eventos, etc.).
- Exercitar Git Flow (branch, PR, revisão, justificativa técnica).

## Grupos e Padrões Principais
| Grupo | Padrão | Pasta Principal | Entrega | Observações |
|-------|--------|-----------------|---------|-------------|
| 1 | Repository Pattern | `Infrastructure/Repositories` | `ProdutoRepository` | Focar em persistência, sem regra de negócio |
| 2 | Service (Application Service) | `Application/Services` | `ProdutoService` | Orquestra e centraliza regras |
| 3 | DTO + Mapping | `Application/DTOs` / `Application/Services` | DTOs + mapping | Desacoplar entidade do contrato externo |
| 4 | Validation (FluentValidation) | (a criar) | Validators | Padronizar erros e mensagens |
| 5 | Factory | `Application/Services` | `ProdutoFactory` | Garantir invariantes de criação |

(Se não houver grupo para Validation ainda, ficará como extra.)

## Ordem Sugerida de Integração
1. Repository
2. Service
3. Factory + DTO/Mapping (podem andar em paralelo se coordenados)
4. Validation (após DTO pronto)

## Branch Naming
`feature/<nome-padrao>` – exemplos:
- `feature/repository`
- `feature/service`
- `feature/dto-mapping`
- `feature/factory`
- `feature/validation`

## Checklist de PR
- [ ] Branch criada corretamente
- [ ] Escopo único (apenas o padrão do grupo)
- [ ] README da pasta atualizado/expandido
- [ ] Código compila (`dotnet build`)
- [ ] Explicação: Quando NÃO usar este padrão
- [ ] (Opcional) Teste simples
- [ ] Endpoints ainda funcionam (quando integrados)

## Critérios de Avaliação (Rubrica Simplificada)
| Critério | Peso |
|----------|------|
| Implementação correta do padrão | 4 |
| Separação de responsabilidades | 3 |
| Clareza (nomes / organização) | 2 |
| Documentação / justificativa | 2 |
| Integração sem quebrar API | 2 |
| Extras (testes, reflexão crítica) | +2 bônus |

## Próximos Passos dos Grupos
- Abrir PR cedo em modo rascunho (draft) para receber feedback.
- Escrever no corpo do PR: Antes/Depois (trecho de código breve) e justificativa.
- Não misturar mudanças não relacionadas (ex: não configurar logging agora).

## Dúvidas Frequentes
**Por que não deixar tudo nos endpoints?** Para escalar manutenção e testar regras isoladamente.
**Repository + EF Core é redundante?** Em projetos simples, sim — justificar no PR.
**Preciso usar AutoMapper?** Não; mapping manual é pedagógico.
**Onde ficam validações?** Invariantes críticas podem estar na Factory; validações de entrada no Validator.


Boa implementação! Lembrem-se de justificar escolhas, não só “fazer”.

---
### Documentação da Estrutura do Projeto
Para uma explicação detalhada das camadas, responsabilidades e decisões didáticas, consulte o documento:
`docs/EstruturaProjeto.md`

Esse material ajuda a entender onde cada novo arquivo deve ser colocado conforme o projeto evoluir.
