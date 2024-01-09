namespace BookManager.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<User> Users { get; set; } = new List<User>();
  
        public void RegisterUser()
        {
            Console.WriteLine("Cadastre um usuário:");

            Console.WriteLine("Digite o nome:");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("O campo nome não pode ser vazio. Por favor, insira um nome válido.");
                name = Console.ReadLine();
            }

            Console.WriteLine("Digite o email:");
            var email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("O campo email não pode ser vazio. Por favor, insira um email válido.");
                email = Console.ReadLine();
            }

            User user = new()
            {
                Id = Id,
                Name = name,
                Email = email
            };
            Users.Add(user);

            Console.WriteLine($"Usuário cadastrado com sucesso !! ID: {user.Id}, Nome: {user.Name}, Email: {user.Email}");
        }
    }

}
