using dotNetAPI.Models;

namespace dotNetAPI.Controllers
{
    public static class PessoasController
    {
        public static List<Pessoas> Pessoas = new()
        {
            new(Guid.NewGuid(), "Neymar"),
            new(Guid.NewGuid(), "CR7"),
            new(Guid.NewGuid(), "Messi"),
        };

        public static void MapPessoasRotas(this WebApplication app)
        {
            app.MapGet("/pessoas", () => Pessoas);

            app.MapGet("/pessoas/{name}",
                (string name) => Pessoas.Find(x => x.Name == name));

            app.MapPost("/pessoas",
                (Pessoas pessoa) =>
                {
                    Pessoas.Add(pessoa);
                    return pessoa;
                });

            app.MapPut("/pessoas/{id:guid}", (Guid id, Pessoas pessoa) =>
                {
                    var encontrado = Pessoas.Find(x => x.Id == id);
                    if (encontrado == null)
                    {
                        Results.NotFound();
                    }
                    else
                    {
                        encontrado.Name = pessoa.Name;
                    }

                    return Results.Ok(encontrado);
                });

            app.MapDelete("/pessoas/{id}", (Guid id) =>
            {
                var encontrado = Pessoas.Find(x => x.Id == id);
                if (encontrado == null)
                {
                    return Results.NotFound("Pessoa não encontrada.");
                }
                else
                {
                    Pessoas.Remove(encontrado);
                    return Results.Ok("Pessoa removida com sucesso.");
                }
            });
        }
    }
}
