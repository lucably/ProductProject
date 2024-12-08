using Flunt.Validations;
using System.Diagnostics.Contracts;

namespace ProductProject.Domain.Product
{
    public class Category : Entity
    {
        public string Name { get; set; }

        //Valor default = true;
        public bool Active { get; set; }

        public Category(string name, string createdBy, string editedBy, bool active)
        {
            //Contract => Usando o pacote do FLUNT para validações
            //.IsNotNull(name, "Name") => Estamos dizendo que a variavel vinda do construtor name nao pode ser nulo e "Name" nome da propriedade que é obrigatorio
            var contract = new Contract<Category>()
                .IsNotNullOrEmpty(name, "Name", "Nome é obrigatório")
                .IsGreaterOrEqualsThan(name, 3, "Name", "Nome deve ter pelo menos 3 caracteres")
                .IsNotNullOrEmpty(createdBy, "CreatedBy", "CreatedBy é obrigatório")
                .IsNotNullOrEmpty(editedBy, "EditedBy", "EditedBy é obrigatório");
            AddNotifications(contract);

            Name = name;
            Active = active;
            CreatedBy = createdBy;
            EditedBy = editedBy;
            CreatedOn = DateTime.Now;
            EditedOn = DateTime.Now;
        }
    }
}
