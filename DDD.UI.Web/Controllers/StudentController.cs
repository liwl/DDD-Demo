using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.UI.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/list-all")]
        public IActionResult Index()
        {
            return View(_studentAppService.GetAll());
        }



        // GET: Student/Create
        // 页面
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // 方法
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            try
            {
                ViewBag.ErrorData = null;
                // 视图模型验证
                if (!ModelState.IsValid)
                    return View(studentViewModel);

                //添加命令验证，采用构造函数方法实例
                RegisterStudentCommand registerStudentCommand = new RegisterStudentCommand(studentViewModel.Name, studentViewModel.Email, studentViewModel.BirthDate,"");

                //如果命令无效，证明有错误
                if (!registerStudentCommand.IsValid())
                {
                    List<string> errorInfo = new List<string>();
                    //获取到错误，请思考这个Result从哪里来的 
                    foreach (var error in registerStudentCommand.ValidationResult.Errors)
                    {
                        errorInfo.Add(error.ErrorMessage);
                    }
                    //对错误进行记录，还需要抛给前台
                    ViewBag.ErrorData = errorInfo;
                    return View(studentViewModel);
                }
                // 执行添加方法
                _studentAppService.Register(studentViewModel);
                ViewBag.Sucesso = "Student Registered!";
                return View(studentViewModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}