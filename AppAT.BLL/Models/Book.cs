﻿
namespace AppAT.BLL.Models
{
    public  class Book
    {
        public int BookId { get; set; }

        public string Isbn { get; set; }

        public string Title { get; set; }

        public virtual IList<AuthorBook> AuthorBook { get; set; }
    }
}
