using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Application
{
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }

    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static Result<T> Success<T>(T result, string message = null)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Message = message,
                Data = result
            };
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}
