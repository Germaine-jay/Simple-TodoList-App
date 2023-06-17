using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoList.BLL.Interfaces;
using TodoList.BLL.Models;

namespace TodoList.MVC.Controllers
{

    [Route("[controller]/[action]/{userid?}")]
    [AutoValidateAntiforgeryToken]
    public class TodoListController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITodoListService _todoService;
        private readonly IMapper _mapper;


        public TodoListController(IUserService userService, ITodoListService todoService)
        {
            _userService = userService;
            _todoService = todoService;
        }

        public async Task<IActionResult> Home()
        {
            var model = await _userService.GetUsersWithTasksAsync();
            return View(model);
        }


        [HttpGet("{taskId?}")]
        public async Task<IActionResult> New(int userId, int taskId)
        {
            if (string.IsNullOrEmpty(taskId.ToString()))
            {
                return View(new AddOrUpdateTaskVM { UserId = userId });
            }
            return View(new AddOrUpdateTaskVM());
        }

        [HttpGet("{taskId?}")]
        public async Task<IActionResult> UpdateTask(int userId, int taskId)
        {
            var user = await _todoService.GetTask(userId, taskId);
            return View(user);

        }


        [HttpPost]
        public async Task<IActionResult> Save(AddOrUpdateTaskVM model)
        {
            if (ModelState.IsValid)
            {
                var (successful, msg) = await _todoService.AddOrUpdateAsync(model);
                if (successful)
                {
                    TempData["SuccessMsg"] = msg;            
                    return RedirectToAction("Home");
                }
                ViewBag.ErrMsg = msg;
                return View("New");
            }
            return View("New");
        }


        [HttpGet("{taskId}")]
        public async Task<IActionResult> DeleteTask(int userId, int taskId)
        {
            if (ModelState.IsValid)
            {
                var (success, msg) = await _todoService.DeleteTaskAsync(userId, taskId);

                if (success)
                {
                    TempData["SuccessMsg"] = msg;
                    return RedirectToAction("Home");
                }

                TempData["ErrMsg"] = msg;
                return RedirectToAction("Home");
            }
            return View("Home");
        }


        [HttpGet("{taskId}")]
        public async Task<IActionResult> SaveUpdateStatus(int userId, int taskId)
        {

            if (ModelState.IsValid)
            {
                var (successful, msg) = await _todoService.ToggleTaskStatus(userId, taskId);

                if (successful)
                {
                    TempData["SuccessMsg"] = msg;
                    return RedirectToAction("Home");
                }

                TempData["ErrMsg"] = msg;
                return View("Home");

            }
            return View("Home");
        }

    }
}
