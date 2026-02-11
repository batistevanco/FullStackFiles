using AutomaticIncoding.Models;

namespace AutomaticIncoding.ViewModels
{
    public class CommentPageVM
    {
        public CommentVM? NewComment { get; set; }

        public List<CommentVM>? PostedComments { get; set; }

    }

    public class CommentVM
    {
        public string? Name { get; set; }
        public string? Message { get; set; }
    }
}
