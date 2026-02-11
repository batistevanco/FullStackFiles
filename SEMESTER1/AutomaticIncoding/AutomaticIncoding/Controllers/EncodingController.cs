using AutomaticIncoding.Models;
using AutomaticIncoding.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AutomaticIncoding.Controllers
{
    public class EncodingController : Controller
    {
        private static readonly List<CommentVM> _comments = new();

        public IActionResult Index()
        {
            var vm = new CommentPageVM
            {
                PostedComments = _comments
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(CommentPageVM commentPageVM)
        {
            if (ModelState.IsValid && commentPageVM.NewComment is not null)
            {
                _comments.Add(commentPageVM.NewComment);
            }
            
            var vm = new CommentPageVM
            {
                PostedComments = _comments
            };

            ModelState.Clear(); //verwijdert oude invoer na post
            return View(vm);

        }
    }
}
