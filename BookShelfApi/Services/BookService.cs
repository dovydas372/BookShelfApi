using BookShelfApi.Dtos;
using BookShelfApi.Models;
namespace BookShelfApi.Services

{
    public class BookService
    {
        private readonly List<Book> _books = new();

        private int _nextId = 1;

        public List<Book> GetAll() 
        { 
            return _books;
        }

        public Book? GetById(int id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }

        public Book Create(CreateBookDTO dto)
        {
            var book = new Book
            {
                Id = _nextId++,
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year,
                IsRead = false
            };

            _books.Add(book);
            return book;
        }

        public bool MarkAsRead(int id)
        {
            var book = GetById(id);

            if (book is null)
            {
                return false;
            }

            book.IsRead = true;

            return true;
        }

        public bool Delete(int id)
        {
            var book = GetById(id);

            if (book is null)
            {
                return false;
            }

            _books.Remove(book);

            return true;
        }
    }
}
