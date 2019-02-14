using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Models;

namespace Trello.Controllers
{
    public class TrelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeeAllBoards()
        {
            var trelloService = new TrelloService();

            TrelloVm vm = new TrelloVm();
            vm.Boards = trelloService.GetAllBoards().Result;

            return View("SeeAllBoards",vm);
        }

        public IActionResult SeeAllBoardLists()
        {
            var trelloService = new TrelloService();

            TrelloVm vm = new TrelloVm();
            vm.Lists = trelloService.GetAllListsForBoard("5c5bec8b2e25ff7be13fb912").Result;

            return View("SeeAllBoardLists");
        }

        public IActionResult AddPost()
        {
            return View("AddPost");
        }

        public IActionResult CreatePost(Post post)
        {
            var trelloService = new TrelloService();

            trelloService.CreateAcardOnAlist("5c5bec8b2e25ff7be13fb913", post.Name, post.Description).Wait();

            return View("PostSuccess", post);
        }
    }
}
