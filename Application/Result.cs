﻿namespace ApiResultPattern.Application
{
    public class Result<T> where T : class
    {
        private Result(bool isSuccess, Error error, T data)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error.", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
            Data = data;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        public T Data { get; }
        public static Result<T> Success(T data) => new Result<T>(true, Error.None, data);
        public static Result<T> Failure(Error error) => new Result<T>(false, error, null!);

    }
}
