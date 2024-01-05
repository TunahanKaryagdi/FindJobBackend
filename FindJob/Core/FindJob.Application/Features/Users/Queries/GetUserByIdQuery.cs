using Core.Utilities.Results;
using FindJob.Application.Features.Skill.Dtos;
using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Repositories;
using FindJob.Application.Services;
using FindJob.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Application.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<IDataResult<UserDetailDto>>
    {
        public string Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IDataResult<UserDetailDto>>
        {

            IUserService _userService;

            public GetUserByIdQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async  Task<IDataResult<UserDetailDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                UserDetailDto userDetailDto = await _userService.GetUserById(request.Id);
                return new SuccessDataResult<UserDetailDto>(userDetailDto,"user get successfully");
               
            }
        }
    }
}
