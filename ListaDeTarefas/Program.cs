var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

var tarefas = new List<Tarefa>();

// Get /tarefas - Listar todas as tarefas
app.MapGet("/tarefas", () =>
{
    return Results.Ok(tarefas);
});

// Get /tarefas/{id} - Buscar tarefa por id
app.MapGet("/tarefas/{id:int}", (int id) =>
{
    Tarefa tarefaEncontrada = null;
    foreach (var tarefa in tarefas)
    {
        if (tarefa.Id == id)
        {
            tarefaEncontrada = tarefa;
            return Results.Ok(tarefaEncontrada);
        }

    };
    return Results.NotFound($"Tarefa com id {id} não encontrada!");
});

// Put /tarefas/id - atualizar tarefa existente
app.MapPut("/tarefas/{id:int}", (int id, Tarefa tarefaAtualizada) =>
{
    var tarefaExistente = tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
    if (tarefaExistente == null)
        return Results.NotFound($"Tarefa com id {id} não foi encontrada!");
    tarefaExistente.Titulo = tarefaAtualizada.Titulo;
    tarefaExistente.Descricao = tarefaAtualizada.Descricao;
    tarefaExistente.concluida = tarefaAtualizada.concluida;
    return Results.Ok(tarefaExistente);
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
