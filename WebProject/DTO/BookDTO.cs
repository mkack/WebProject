using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Enums;

namespace WebProject.DTO
{
    public class BookDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Descrtiption { get; set; }

        public BookType BookType { get; set; }
    }
}
