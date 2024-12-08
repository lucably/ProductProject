using Microsoft.AspNetCore.Mvc;
using ProductProject.Domain.Product;
using ProductProject.Infra.Data;

namespace ProductProject.Endpoints.Categories;

public class CategoryPut
{
    // a seta "=>" significa que ao criar ja atribui o valor a variavel template.
    // Colocando na rota {id:guid} esse ":guid" informa que só sera aceito se o ID passado for guid, caso contrario, retornara um 404 NOT FOUND
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute]Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null || categoryRequest.Name == null)
        {
            return Results.NotFound();
        }

        category.Name = categoryRequest.Name;
        category.Active = categoryRequest.Active;
        context.SaveChanges();

        return Results.Ok();
    }
}
