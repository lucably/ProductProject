using ProductProject.Domain.Product;
using ProductProject.Infra.Data;

namespace ProductProject.Endpoints.Categories;

public class CategoryGetAll
{
    // a seta "=>" significa que ao criar ja atribui o valor a variavel template.
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();
        var response = categories.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name, Active = c.Active });

        return Results.Ok(response);
    }
}
