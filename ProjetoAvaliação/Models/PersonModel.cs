namespace ProjetoAvaliação.Models
{
    public class PersonModel
    {
        public PersonModel(int id , string name, int idade)
        {
            Id = id;
            Name = name;
            Idade = idade;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Idade { get; set; }


    }
}
