using AutoMapper;
using Employees.Application.Employees.Commands.CreateEmployee;
using Employees.Application.Employees.Commands.DeleteEmployee;
using Employees.Application.Employees.Commands.UpdateEmployee;
using Employees.Application.Employees.Queries.GetEmployeeDetails;
using Employees.Application.Employees.Queries.GetEmployeesList;
using Employees.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Employees.Web.Controllers
{
    [Route("employees")]
    public class EmployeesController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly IMapper _mapper;
        public EmployeesController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Route("list")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(DataRequest request)
        {
            var query = new GetEmployeesListQuery
            {
                PageNumber = request.PageNumber,
                SearchString = request.SearchString
            };
            var vm = await Mediator.Send(query);
            return PartialView("_GetEmployees", vm);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteEmployeeCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return RedirectToAction("list", "employees");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateEmployeeDto createEmployeeDto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
            await Mediator.Send(command);
            return RedirectToAction("list", "employees");
        }


        [HttpGet]
        [Route("update")]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetEmployeeDetailsQuery
            {
                Id = id
            };
            var requestVm = await Mediator.Send(query);
            var vm = new UpdateEmployeeDto 
            { 
                Id = id, 
                Name = requestVm.Employee.Name,
                DepartmentId = requestVm.Employee.DepartmentId,
                PhoneNumber = requestVm.Employee.PhoneNumber
            };
            return View(vm);
        }
        
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult> Update(UpdateEmployeeDto updateEmployeeDto, int id)
        {
            updateEmployeeDto.Id = id;
            var command = _mapper.Map<UpdateEmployeeCommand>(updateEmployeeDto);
            await Mediator.Send(command);
            return RedirectToAction("list", "employees");
        }
    }
}
