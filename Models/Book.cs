using System.ComponentModel.DataAnnotations;
using TestWebApi.Interfaces;

namespace TestWebApi.Models
{
    public class Book
        : IHaveId
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
    }
}