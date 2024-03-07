using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Models
{
    public class Book
    {
        public int? id { get; set; }
        public string? author { get; set; }

        public override string ToString()
        {
            return $"book author:{author}, book id: {id}";
        }

    }
}
