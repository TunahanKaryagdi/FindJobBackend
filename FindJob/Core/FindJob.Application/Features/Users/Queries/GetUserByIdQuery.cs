using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Services;
using FindJob.Application.Utilities.Results;
using MediatR;

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

            public async Task<IDataResult<UserDetailDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                UserDetailDto userDetailDto = await _userService.GetUserById(request.Id);
                return new SuccessDataResult<UserDetailDto>(userDetailDto, "user get successfully");

            }
        }
    }
}
