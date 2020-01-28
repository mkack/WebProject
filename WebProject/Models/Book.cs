using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Enums;

namespace WebProject.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; protected set; }

        [Required]
        [Column(TypeName= "varchar(100)")]
        public string Title { get; protected set; }

        [Required]
        [Column(TypeName = "varchar(40)")]
        public string Author { get; protected set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Descrtiption { get; protected set; }

        [Required]
        public BookType BookType { get; protected set; } 

        protected Book()
        {
        }

        public Book (string title, string author, string descritpion, BookType bookType)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Author = author;
            this.Descrtiption = descritpion;
            this.BookType = bookType;
        }
    }
}
