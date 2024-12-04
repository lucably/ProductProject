namespace ProductProject.Domain;

// classe abstract => Ela nao pode ser instanciada somente herdada
public abstract class Entity
{

    //Construtor para já gerar um novo ID;
    public Entity() 
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public string EditedBy { get; set; }
    public DateTime EditedOn { get; set; }
}
