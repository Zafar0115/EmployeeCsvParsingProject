using EmployeeTask.CQRS.Commands;
using EmployeeTask.CQRS.Queries;
using EmployeeTask.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _mediator.Send(new EmployeeRetrieveAllQuery());
            return View(employees.ToList());
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromForm] ParseFileCommand command)
        {
            var parsedEmployees = await _mediator.Send(command);
            int rowsAffected = await _mediator.Send(new EmployeeAddRangeCommand() { Employees = parsedEmployees });
            return View("Success", rowsAffected);
        }


        [HttpPost]
        public async Task<IActionResult> Filter([FromForm] FilterQuery query)
        {
            var employees = await _mediator.Send(query);
            employees = employees == null ? new List<Employee>() : employees.ToList();
            return View("Index", employees);
        }


        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EmployeeUpdateCommand command)
        {
            bool isSuccess = await _mediator.Send(command);
            return isSuccess ? RedirectToAction("Index")
                 : View("Error", new Error { ErrorMessage = "Invalid entries. Changes can not be updated" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] EmployeeDeleteCommand command)
        {
            bool isSuccess = await _mediator.Send(command);
            return isSuccess ? RedirectToAction("Index") : View("Error", new Error { ErrorMessage = $"No employee found with payyroll: {command.PayyrollNumber}" });
        }

        public async Task<IActionResult> Error(Error error)
        {
            return View(error);
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}