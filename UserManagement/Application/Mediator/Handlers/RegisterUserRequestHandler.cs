using MediatR;
using UserManagement.Application.DTOs;
using UserManagement.Application.Mediator.Requests;
using UserManagement.Application.Services;

namespace UserManagement.Application.Mediator.Handlers;

internal class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, ResultDTO<Guid>>
{
    private IUserService UserService { get; }

    public RegisterUserRequestHandler(IUserService userService)
    {
        UserService = userService;
    }

    public async Task<ResultDTO<Guid>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var a = await UserService.RegisterAsync(request.RegisterDto);
        return a;
    }
}