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
        /*
            Como eu coloquei no metodo set dentro do category => private set; 
            Eu nao consigo setar(mudar) a variavel sem ser dentro da Class Category, portanto, o codigo como estava antes nao irá funcionar:
            
            category.Name = categoryRequest.Name;
            category.Active = categoryRequest.Active;

            tendo que setar agora baseado no metodo criado dentro da class "EditInfo"
         */

        category.EditInfo(categoryRequest.Name, categoryRequest.Active);

        if (!category.IsValid) return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
       
        context.SaveChanges();

        return Results.Ok();
    }
}
