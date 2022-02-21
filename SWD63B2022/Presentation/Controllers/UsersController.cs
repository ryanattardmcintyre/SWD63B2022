using Common;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class UsersController : Controller
    {
        private IFireStoreDataAccess fireStore;
        public UsersController(IFireStoreDataAccess _fireStore)
        {
            fireStore = _fireStore;
        }

        [Authorize]
        public async Task< IActionResult> Index()
        {
            var myUser = await fireStore.GetUser(User.Claims.ElementAt(4).Value);
            if(myUser == null)
            {
                myUser = new Common.User();
                myUser.Email = User.Claims.ElementAt(4).Value;
            }
            return View(myUser);
        }

        public IActionResult Register(User user)
        {
            user.Email = User.Claims.ElementAt(4).Value;
            fireStore.AddUser(user);
            return RedirectToAction("Index");
        }

        [HttpGet][Authorize]
        public IActionResult Send( )
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task< IActionResult> Send(Message msg)
        {
            msg.Id = Guid.NewGuid().ToString();
           await fireStore.SendMessage(User.Claims.ElementAt(4).Value, msg);
            return RedirectToAction("List");
        }
       
        [Authorize]
        public async Task<IActionResult> List()
        {
            var messages = await fireStore.GetMessages(User.Claims.ElementAt(4).Value);
            return View(messages);
        }
    }
}
