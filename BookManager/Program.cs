using BookManager.Entities;

class Program
{
    static void Main()
    {
        Options options = new();
        Book book = new();
        User user = new();
        Loan loan = new();

        do
        {
            options.ShowOptions();
            int choice = options.ReadChoose();

            switch (choice)
            {
                case 1:
                    book.RegisterBook();
                    break;
                case 2:
                    book.ListBooks();
                    break;
                case 3:
                    book.SearchBook();
                    break;
                case 4:
                    book.RemoveBook();
                    break;
                case 5:
                    user.RegisterUser();
                    break;
                case 6:
                    loan.RegisterLoan(user.Id, book.Id);
                    break;
                case 7:
                    loan.ReturnBook();
                    break;
                case 0:
                    Console.WriteLine("Saindo do programa. Até logo!");
                    break;
                default:
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                    break;
            }

        } while (true);
    }
}
