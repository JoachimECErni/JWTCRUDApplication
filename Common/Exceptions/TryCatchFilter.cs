using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CRUDApplication.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Controllers;

public class TryCatchFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Cast to ControllerActionDescriptor to access controller type and action name
        var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

        if (actionDescriptor == null)
        {
            await next();
            return;
        }

        // Get the method info for the action
        var methodInfo = actionDescriptor.MethodInfo;

        // Check if the action method has the TryCatchAttribute
        var hasTryCatchAttribute = methodInfo.GetCustomAttributes(typeof(TryCatchAttribute), false).Any();

        if (hasTryCatchAttribute)
        {
            try
            {
                await next();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, return a specific response, etc.)
                Console.WriteLine($"An error occurred: {ex.Message}");
                context.Result = new ObjectResult(new { error = "An error occurred while processing your request." })
                {
                    StatusCode = 69 // Internal Server Error
                };
            }
        }
        else
        {
            await next();
        }
    }
}