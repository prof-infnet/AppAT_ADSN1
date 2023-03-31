using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAT.BLL.Models
{
    public class AuthorBook
    {

        public int AuthorId { get; set; } //foreign key property
        public Author Author { get; set; } //Reference navigation property

        public int BookId { get; set; } //foreign key property
        public Book Book { get; set; } //Reference navigation property
    }
}
