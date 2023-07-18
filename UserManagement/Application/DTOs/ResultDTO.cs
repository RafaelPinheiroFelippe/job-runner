using FluentResults;

namespace UserManagement.Application.DTOs;


public class ResultDTO
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess; 
    public List<string> Errors { get; }    

    public ResultDTO(Result result)
    {
        IsSuccess = result.IsSuccess;
        Errors = result.Errors.Select(e => e.Message).ToList();
    }

    public static implicit operator ResultDTO(Result result) => new(result);
}

public class ResultDTO<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public List<string> Errors { get; }
    public T? Value { get; }

    private ResultDTO(Result<T> result)
    {
        Value = result.IsSuccess ? result.Value : default;
        IsSuccess = result.IsSuccess;
        Errors = result.Errors.Select(e => e.Message).ToList();
    }

    public static implicit operator ResultDTO<T>(Result<T> result) => new(result);
}