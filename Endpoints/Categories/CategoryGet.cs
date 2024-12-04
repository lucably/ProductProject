using Microsoft.AspNetCore.Mvc;
using ProductProject.Domain.Product;
using ProductProject.Infra.Data;

namespace ProductProject.Endpoints.Categories;

public class CategoryGet
{
    // a seta "=>" significa que ao criar ja atribui o valor a variavel template.
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute]Guid id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null)
        {
            return Results.NotFound();
        }

        var response = new CategoryResponse { Id = category.Id, Name = category.Name, Active = category.Active };

        return Results.Ok(response);
    }
}
