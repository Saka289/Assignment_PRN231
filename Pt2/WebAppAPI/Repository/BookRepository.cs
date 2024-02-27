using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAppAPI.Data;
using WebAppAPI.Models;
using WebAppAPI.Models.Dtos;

namespace WebAppAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateBook(BookDto bookDto)
        {
            try
            {
                Book model = _mapper.Map<Book>(bookDto);
                if (model != null)
                {
                    _context.Books.Add(model);
                    _context.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        public bool DeleteBook(int id)
        {
            try
            {
                var bookAuthor = _context.BookAuthors.Where(b => b.book_id == id).ToList();
                if (bookAuthor != null)
                {
                    _context.BookAuthors.RemoveRange(bookAuthor);
                    var book = _context.Books.FirstOrDefault(b => b.book_id == id);
                    if (book != null)
                    {
                        _context.Books.Remove(book);
                        _context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            try
            {
                var result = _context.Books.ToList();
                IEnumerable<BookDto> bookDtos = _mapper.Map<IEnumerable<BookDto>>(result);
                return bookDtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BookDto GetBook(int id)
        {
            try
            {
                var result = _context.Books.FirstOrDefault(b => b.book_id == id);
                var bookDtos = _mapper.Map<BookDto>(result);
                return bookDtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<BookDto> SearchBook(string text)
        {
            try
            {
                var result = _context.Books
                    .Include(b => b.BookAuthors)
                    .ThenInclude(a => a.Author)
                    .Where(x => x.title.ToLower().Contains(text.ToLower()) || x.BookAuthors.Any(a => a.Author.email_address.ToLower().Equals(text.ToLower())))
                    .ToList();
                var bookDtos = _mapper.Map<IEnumerable<BookDto>>(result);
                return bookDtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateBook(BookDto bookDto)
        {
            try
            {

                var book = _context.Books.FirstOrDefault(b => b.book_id == bookDto.book_id);
                if (book != null)
                {
                    _mapper.Map(bookDto, book);
                    _context.SaveChanges();
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
