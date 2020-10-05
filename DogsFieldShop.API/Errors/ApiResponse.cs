using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogsFieldShop.API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request",
                401 => "Authorised, you are not",
                404 => "Resource found, it was not",
                500 => "Hate leads to career change...",
                _ => null,
            };
        }
    }
}
