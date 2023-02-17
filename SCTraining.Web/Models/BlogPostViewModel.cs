using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCTraining.Web.Models
{
    public class BlogPostViewModel
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public DateTime BlogPostDate { get; set; }
        public Author Author { get; set; }
        public string BlogImage { get; set; }
    }

    public class Author
    {
        public string AuthorName { get; set; }
        public string Designation { get; set; }
        public string AuthorImage { get; set; }
        public string Summary { get; set; }
    }
}