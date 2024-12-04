using Microsoft.AspNetCore.Mvc;
using ProductProject.Domain.Product;
using ProductProject.Infra.Data;

namespace ProductProject.Endpoints.Categories;

public class CategoryDelete
{
    // a seta "=>" significa que ao criar ja atribui o valor a variavel template.
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute]Guid id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null) 
        {
            return Results.NotFound();
        }

        context.Remove(category);
        context.SaveChanges();

        return Results.Ok();
    }
}
