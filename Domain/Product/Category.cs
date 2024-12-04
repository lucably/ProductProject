namespace ProductProject.Domain.Product
{
    public class Category : Entity
    {
        public string Name { get; set; }

        //Valor default = true;
        public bool Active { get; set; } = true;
    }
}
