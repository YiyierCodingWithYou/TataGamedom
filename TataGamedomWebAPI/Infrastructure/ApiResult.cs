using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TataGamedomWebAPI.Infrastructure
{
    public class ApiResult
    {

        public bool IsSuccess { get; private set; }
        public bool IsFail => !IsSuccess;
        public string? Message { get; private set; }
        public string? OptionContent { get; private set; }

        public static ApiResult Success(string succMessage, string optionContent = "") => new ApiResult { IsSuccess = true, Message = succMessage, OptionContent = optionContent };
        public static ApiResult Fail(string errorMessage, string optionContent = "") => new ApiResult { IsSuccess = false, Message = errorMessage, OptionContent = optionContent };

    }
}