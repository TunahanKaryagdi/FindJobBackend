using FindJob.Application.Features.Users.Dtos;
using FindJob.Application.Services;
using FindJob.Application.Utilities.Results;
using MediatR;

namespace FindJob.Application.Features.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IDataResult<List<UserDetailDto>>>
    {

        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IDataResult<List<UserDetailDto>>>
        {
            IUserService _userService;

            public GetAllUsersQueryHandler(IUserService userService)
            {
                _userService = userService;
            }
            public async Task<IDataResult<List<UserDetailDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var users = _userService.GetAllUsers();
                return new SuccessDataResult<List<UserDetailDto>>(users, "");
            }
        }


    }
}
