using ProductProject.Domain.Product;
using ProductProject.Infra.Data;

namespace ProductProject.Endpoints.Categories;

public class CategoryPost
{
    // a seta "=>" significa que ao criar ja atribui o valor a variavel template.
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = new Category(categoryRequest.Name, "Lucas", "No one", categoryRequest.Active);

        //IsValid veio herdado da Classe Entity do Notifiable
        if (!category.IsValid) 
        {
            var erros = category.Notifications
                .GroupBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());

            return Results.ValidationProblem(erros);
        }

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}
