namespace BookManager.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime? LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }


        public void RegisterLoan(Guid userId, Guid bookId)
        {
            Console.WriteLine("Cadastre a data de retirada do livro:");

            Console.Write("Dia (dd): ");
            int day;
            while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31)
            {
                Console.WriteLine("Dia inválido. Digite novamente.");
            }

            Console.Write("Mês (MM): ");
            int month;
            while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
            {
                Console.WriteLine("Mês inválido. Digite novamente.");
            }

            Console.Write("Ano (yyyy): ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Ano inválido. Digite novamente.");
            }

            DateTime loanDate = new(year, month, day);
            ReturnDate = loanDate.AddDays(5);

            Loan loan = new()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                BookId = bookId,
                LoanDate = loanDate
            };

            Console.WriteLine($"Empréstimo registrado com sucesso ID: {loan.Id}, Usuário: {loan.UserId}, Livro: {loan.BookId}, Data de Retirada: {loan.LoanDate}, Data de Devolução: {ReturnDate}");
        }

        public void ReturnBook()
        {
            Console.WriteLine("Registre a devolução do livro: ");

            Console.Write("Dia (dd): ");
            int day;
            while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31)
            {
                Console.WriteLine("Dia inválido. Digite novamente.");
            }

            Console.Write("Mês (MM): ");
            int month;
            while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
            {
                Console.WriteLine("Mês inválido. Digite novamente.");
            }

            Console.Write("Ano (yyyy): ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Ano inválido. Digite novamente.");
            }

            DateTime returnDate = new(year, month, day);

            int daysDelay = (int)(returnDate - ReturnDate!.Value).TotalDays;

            if (daysDelay > 0)
            {
                Console.WriteLine($"Devolução com {daysDelay} dia(s) de atraso.");
            }
            else
            {
                Console.WriteLine("Devolução realizada em dia.");
            }

        }
    }
}
