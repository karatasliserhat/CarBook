﻿namespace UdemyCarBook.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}