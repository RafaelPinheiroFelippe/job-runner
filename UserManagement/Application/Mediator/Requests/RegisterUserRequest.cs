using MediatR;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.Mediator.Requests;

public record RegisterUserRequest(RegisterDto RegisterDto) : IRequest<ResultDTO<Guid>>;