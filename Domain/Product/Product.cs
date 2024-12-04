namespace ProductProject.Domain.Product;

public class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public bool HasStock { get; set; }

    //Alegando que CategoryId é obrigatório
    public Guid CategoryId { get; set; }

    //Valor default = true;
    public bool Active { get; set; } = true;

}
