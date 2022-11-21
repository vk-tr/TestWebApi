using System;
using System.Collections.Generic;
using System.Linq;
using TestWebApi.Contexts;
using TestWebApi.Exceptions;
using TestWebApi.Helpers;
using TestWebApi.Interfaces;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public class BooksService
    {
        private readonly IRepository _repository;

        public BooksService()
        {
            _repository = new Repository(new DataBaseContext());
        }

        public void CreateSample()
        {
            var book1 = new Book
            {
                Title = "Harry Potter and Philosophy Stone",
                Author = "J.K. Rolling"
            };

            var book2 = new Book
            {
                Title = "The Witcher",
                Author = "A. Sapkovski"
            };

            var book3 = new Book
            {
                Title = "Пикник на обочине",
                Author = "Братья Стругацкие"
            };

            var book4 = new Book
            {
                Title = "Чистый код",
                Author = "Р. Мартин"
            };

            _repository.Add(book1);
            _repository.Add(book2);
            _repository.Add(book3);
            _repository.Add(book4);
        }

        public IQueryable<Book> GetAll()
        {
            return _repository.GetAll<Book>();
        }

        public void Add(string title, string author)
        {
            var newEntity = new Book
            {
                Title = title,
                Author = author
            };

            _repository.Add(newEntity);
        }

        public IQueryable<Book> GetAvailableBooks()
        {
            var reservationIds = _repository.GetAll<Reservation>()
                .Select(x => x.BookId);

            return _repository.GetAll<Book>()
                .Where(x => !reservationIds.Any(y => y == x.Id));
        }

        public string GetStatusHistory(long bookId)
        {
            var book = _repository.GetAll<Book>()
                .FirstOrDefault(x => x.Id == bookId);

            if (book == default)
            {
                return "No history for that book";
            }

            var historyList = new List<string>();

            historyList.Add($"BOOK: {book.Title} AUTHOR: {book.Author}");

            var statuses = _repository.GetAll<ReservationLog>()
                .Where(x => x.BookId == bookId)
                .OrderBy(x => x.DateTime)
                .ToList();

            foreach (var status in statuses)
            {
                historyList.Add($"DATE: {status.DateTime} "
                    + $"STATUS: {ReservationStatusHelper.GetStatusString(status.Status)} "
                    + $"COMMENT: {status.Comment}");
            }

            return string.Join("\n", historyList);
        }
    }
}