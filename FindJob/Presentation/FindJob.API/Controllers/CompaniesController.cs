﻿using FindJob.Application.Features.Companies.Queries;
using FindJob.Application.Features.Company.Commands;
using FindJob.Application.Features.CompanyStaff.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FindJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {

        private readonly IMediator _mediator;


        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] GetAllCompaniesQuery getAllCompaniesQuery)
        {
            var result = await _mediator.Send(getAllCompaniesQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromForm] string jsonBody, [FromForm] IFormFile? file)
        {
            CreateCompanyCommand command = new CreateCompanyCommand();
            var body = JsonConvert.DeserializeObject<CreateCompanyCommand>(jsonBody);
            command.File = file;
            command.Name = body.Name;

            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("{CompanyId}/WorkingUsers")]
        public async Task<IActionResult> GetUsersByCompanyId([FromRoute] GetCompanyStaffsByCompanyIdQuery getCompanyStaffsByCompanyIdQuery)
        {
            var result = await _mediator.Send(getCompanyStaffsByCompanyIdQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
