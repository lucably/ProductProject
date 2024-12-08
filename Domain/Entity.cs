using Flunt.Notifications;

namespace ProductProject.Domain;

// classe abstract => Ela nao pode ser instanciada somente herdada
//  Notifiable<Notification> => Pacote FLUNT serve para validação de campos
public abstract class Entity : Notifiable<Notification>
{

    //Construtor para já gerar um novo ID;
    public Entity() 
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string EditedBy { get; set; }
    public DateTime EditedOn { get; set; }
}
