using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session15.ViewAndHelpers.Models
{
    public class BlogItem
    {
        public int Id{ get; set; }
        public string Titr { get; set; }
        public string Description { get; set; }

    }
    public class Comment
    {
        public int Id { get; set; }
        public int BlogItemId { get; set; }
        public string Description { get; set; }
    }
    public class Ads
    {
        public int Id { get; set; }
        public string Titr { get; set; }
        public string Description { get; set; }
    }
    public class BlogHomePage
    {
        public List<BlogItem> BlogItems { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Ads> Ads { get; set; }
    }
}
