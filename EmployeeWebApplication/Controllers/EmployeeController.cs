using EmployeeWebApplication.Dto;
using EmployeeWebApplication.Entities;
using EmployeeWebApplication.Mapper;
using EmployeeWebApplication.Service;
using EmployeeWebApplication.Validators;
using EmployeeWebApplication.ViewModel;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics;
using System.Web.Http.OData.Query;

namespace EmployeeWebApplication.Controllers
{
    [ApiController]
    [Route("api/v1/Employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeServiceConcrete _employeeService;
        private readonly EmployeeMapperConcrete _employeeMapper;
        private IValidator<AddEmployeeRequestDto> _addEmployeeValidator;

        public EmployeeController(EmployeeServiceConcrete employeeService, EmployeeMapperConcrete employeeMapper,
            IValidator<AddEmployeeRequestDto> addEmployeeValidator)
        {
            _employeeService = employeeService;
            _employeeMapper = employeeMapper;
            _addEmployeeValidator = addEmployeeValidator;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployeeDirectory(ODataQueryOptions<EmployeeViewModel> oDataQueryOptions)
        {
            var employeeList = await _employeeService.ListAsync();
            var employeeMapper = _employeeMapper.MapList(employeeList).AsQueryable();
            var totalCount = employeeMapper.Count();
            var oDataResult = oDataQueryOptions.ApplyTo(employeeMapper);

            return View(employeeMapper);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequestDto requestDto)
        {
            var validationResult = await _addEmployeeValidator.ValidateAsync(requestDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var addEmployeeResult = await _employeeService.AddAsync(requestDto);

            return View(addEmployeeResult);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] UpdateEmployeeRequestDto requestDto)
        {
            var employeeData = await _employeeService.GetByIdAsync(id);
            var updateEmployeeResult = await _employeeService.UpdateAsync(requestDto, employeeData);

            return View(updateEmployeeResult);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employeeData = await _employeeService.GetByIdAsync(id);
            var removeEmployeeResult = await _employeeService.RemoveAsync(employeeData);

            return View(removeEmployeeResult);
        }
    }
}