namespace BookManager.Entities
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? YearOfPublication { get; set; }
        public List<Book> Books { get; set; } = new List<Book>(); 

        public void RegisterBook()
        {
            Console.WriteLine("Cadastre o Livro:");

            Console.WriteLine("Título:");
            var title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Título não pode ser vazio. Por favor, insira um título válido.");
                title = Console.ReadLine();
            }

            Console.WriteLine("Autor:");
            var author = Console.ReadLine();
            if (string.IsNullOrEmpty(author))
            {
                Console.WriteLine("Autor não pode ser vazio. Por favor, insira um autor válido.");
                author = Console.ReadLine();
            }

            Console.WriteLine("ISBN:");
            var iSBN = Console.ReadLine();
            if (string.IsNullOrEmpty(iSBN))
            {
                Console.WriteLine("ISBN não pode ser vazio. Por favor, insira um ISBN válido.");
                iSBN = Console.ReadLine();
            }

            Console.WriteLine("Ano de Publicação");
            var yearOfPublication = Console.ReadLine();
            int parsedYear;
            while (!int.TryParse(yearOfPublication, out parsedYear) || parsedYear < 0)
            {
                Console.WriteLine("Ano de Publicação inválido. Por favor, insira um ano válido.");
                yearOfPublication = Console.ReadLine();
            }


            Book newBook = new()
            {
                Id = Id,
                Title = title,
                Author = author,
                ISBN = iSBN,
                YearOfPublication = yearOfPublication
            };
            Books.Add(newBook);

            Console.WriteLine("Livro cadastrado com sucesso!");
        }

        public void ListBooks()
        {
            if(Books.Count > 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
            }

            Console.WriteLine("#### Lista de Livros Cadastrados ####");
            foreach (var book in Books)
            {
                Console.WriteLine($"ID: {book.Id}, Título: {book.Title}, Autor: {book.Author}, ISBN: {book.ISBN}, Ano de Publicação: {book.YearOfPublication}");
            }
        }

        public void SearchBook()
        {
            Console.WriteLine("Digite o Titulo do Livro");
            var searchTitle = Console.ReadLine();
            if (string.IsNullOrEmpty(searchTitle))
            {
                Console.WriteLine("Título não pode ser vazio. Por favor, insira um título válido.");
                searchTitle = Console.ReadLine();
            }

            bool bookFound = false;

            foreach (var book in Books)
            {
                if (book.Title?.Equals(searchTitle, StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.WriteLine($"Livro encontrado:\nID: {book.Id}, Título: {book.Title}, Autor: {book.Author}, ISBN: {book.ISBN}, Ano de Publicação: {book.YearOfPublication}");
                    bookFound = true;
                    break;
                }
            }

            if (!bookFound)
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        public void RemoveBook()
        {
            Console.WriteLine("Digite o Título do Livro:");
            var deleteBookTitle = Console.ReadLine();

            if (string.IsNullOrEmpty(deleteBookTitle))
            {
                Console.WriteLine("Título não pode ser vazio. Por favor, insira um título válido.");
                return;
            }

            Book? bookToRemove = null;

            for (int i = Books.Count - 1; i >= 0; i--)
            {
                var book = Books[i];

                if (book.Title?.Equals(deleteBookTitle, StringComparison.OrdinalIgnoreCase) == true)
                {
                    bookToRemove = book;
                    Books.RemoveAt(i);
                    Console.WriteLine($"Livro excluído:\nID: {book.Id}, Título: {book.Title}, Autor: {book.Author}, ISBN: {book.ISBN}, Ano de Publicação: {book.YearOfPublication}");
                    break;
                }
            }

            if (bookToRemove == null)
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
    }
}
