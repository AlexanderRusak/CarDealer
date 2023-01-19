using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.BusinessLogic.Wrappers
{
    public class Result
    {
        public static Result<T> Success<T>(T data, string message = null) => new(data, false, message);

        public static Result<T> Fail<T>(string message, T data = default) => new(data, true, message);
    }

    public class Result<T>
    {
        public Result(T data, bool error, string message)
        {
            Data = data;
            Error = error;
            Message = message;
        }
        public T Data { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
