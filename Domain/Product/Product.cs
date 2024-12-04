namespace ProductProject.Domain.Product;

public class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public bool HasStock { get; set; }

    //Alegando que CategoryId é obrigatório
    public int CategoryId { get; set; }

}
