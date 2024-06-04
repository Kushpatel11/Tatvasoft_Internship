using DataLayer.Entities;
using DataLayer.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BookRepository
    {
        private AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public String InsertBook(BookDetail bookDetail)
        {
            _appDbContext.BookDetails.Add(bookDetail);
            _appDbContext.SaveChanges();
            return "ok";
        }

        public BookDetail GetBookByID(int id)
        {
            var bookDetail = _appDbContext.BookDetails.Where(x => x.Book_id == id).FirstOrDefault();
            return bookDetail;
        }

        public List<BookDetail> GetAllBooks()
        {
            var bookDetails = _appDbContext.BookDetails.ToList();
            return bookDetails;
        }

        public String UpdateBookById(int id, String Author, String Title, String Genre)
        {
            _appDbContext.BookDetails.Where(x => x.Book_id == id).ExecuteUpdate(setters => setters.SetProperty(b => b.Author, Author).SetProperty(b => b.Title, Title).SetProperty(b => b.Genre, Genre));
            _appDbContext.SaveChanges();
            return "ok";
        }

        public String RemoveBookById(int id)
        {
            _appDbContext.BookDetails.Where(x => x.Book_id == id).ExecuteDelete();
            _appDbContext.SaveChanges();
            return "ok";
        }
    }
}
