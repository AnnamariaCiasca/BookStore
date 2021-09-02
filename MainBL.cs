using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.BookStore.Core.Interfaces;
using Week6.EF.BookStore.Core.Models;

namespace Week6.EF.BookStore
{
    public class MainBL //business layer più o meno
    {
        private IBookRepository _bookRepo;
        public MainBL(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        internal void AddBook(Book newBook)
        {
            //validazione
            if (newBook == null) throw new ArgumentNullException();

            _bookRepo.Add(newBook);
        }

        internal Book GetByIsbn(string isbn)
        {
            //validazione 
            if (string.IsNullOrEmpty(isbn)) throw new ArgumentNullException();

            var book = _bookRepo.GetByISBN(isbn);
            return book;
        }

        internal List<Book> FetchBooks()
        {
           var books = _bookRepo.Fetch();
            return books;
        }

        internal void DeleteBook(Book bookToDelete)
        {
            //validazione
            if (bookToDelete == null) throw new ArgumentNullException();

            _bookRepo.Delete(bookToDelete);
        }

        internal void UpdateBook(Book bookToUpdate)
        {
            //validazione input
            if (bookToUpdate == null) throw new ArgumentNullException();

            _bookRepo.Update(bookToUpdate);
        }
    }
}
