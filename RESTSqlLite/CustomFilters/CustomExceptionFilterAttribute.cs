using Microsoft.AspNetCore.Mvc.Filters;
using RESTSqLite.BLL.Interface.Exceptions;
using System;
using Microsoft.AspNetCore.Mvc;

namespace RESTSqLite.CustomFilters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ResourceNotFoundException)
            {
                context.Result = new NotFoundResult();
            }
             
        }
    }
}
