using Flunt.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics.Contracts;

namespace ProductProject.Domain.Product
{
    public class Category : Entity
    {
        //Private set => Deixar editar somente dentro da classe
        public string Name { get; private set; }

        //Valor default = true;
        public bool Active { get; private set; }

        public Category(string name, string createdBy, string editedBy, bool active)
        {
            Name = name;
            Active = active;
            CreatedBy = createdBy;
            EditedBy = editedBy;
            CreatedOn = DateTime.Now;
            EditedOn = DateTime.Now;

            Validate();
        }

        private void Validate()
        {
            //Contract => Usando o pacote do FLUNT para validações
            //.IsNotNull(Name, "Name") => Estamos dizendo que a variavel Name nao pode ser nulo e "Name" se trata da propriedade.
            var contract = new Contract<Category>()
                .IsNotNullOrEmpty(Name, "Name", "Nome é obrigatório")
                .IsGreaterOrEqualsThan(Name, 3, "Name", "Nome deve ter pelo menos 3 caracteres")
                .IsNotNullOrEmpty(CreatedBy, "CreatedBy", "CreatedBy é obrigatório")
                .IsNotNullOrEmpty(EditedBy, "EditedBy", "EditedBy é obrigatório");
            AddNotifications(contract);
        }

        public void EditInfo(string name, bool active)
        {
            Active = active;
            Name = name;

            Validate();
        }
    }
}
