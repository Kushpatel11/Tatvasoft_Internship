using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.Model;

namespace ServiceLayer
{
    public class BookServices
    {
        private readonly List<Book> _book;
        private readonly BookRepository _bookRepository;
        public BookServices(BookRepository bookRepository)
        {
            _book = new List<Book>()
            {
                new Book(){Book_id = 1, Title = "Book1" , Author ="Fayeza" , Genre ="First" },
                new Book(){Book_id = 2, Title = "Book2" , Author ="Fayeza" , Genre ="First" }
            };
            _bookRepository = bookRepository;
        }
        public List<Book> GetAllBooks()
        {
            return _book;
        }

        public Book GetBookByIndex(String index)
        {
            var book = _book[Int32.Parse(index) - 1];
            return book;
        }

        public String updateBook(String index, Book book)
        {
            _book[Int32.Parse(index) - 1] = book;
            return "Ok";
        }


        public String deleteBook(String index)
        {
            _book.RemoveAt(Int32.Parse(index) - 1);
            return "Ok";
        }

        public Book AddBook(Book book)
        {
            _book.Add(book);
            return book;
        }

        /*public async Task<BookDetail> insertBookDetailDb(BookDetail bookDetail) 
        { 
            await _bookRepository.InsertBook(bookDetail);
            return bookDetail;
        }*/

        public String insertBookDetailDb(BookDetail bookDetail)
        {
            _bookRepository.InsertBook(bookDetail);
            return "ok";
        }

        public BookDetail getBookByIDDb(int id)
        {
            var _bookDetail = _bookRepository.GetBookByID(id);
            return _bookDetail;
        }

        public List<BookDetail> getAllBooksDb()
        {
            var _bookDetail = _bookRepository.GetAllBooks();
            return _bookDetail;
        }

        public String updateBookDb(int id, String Author, String Title, String Genre)
        {
            _bookRepository.UpdateBookById(id, Author, Title, Genre);
            return "ok";
        }
        public String deleteBookByIdDb(int id)
        {
            _bookRepository.RemoveBookById(id);
            return "ok";
        }
    }
}
