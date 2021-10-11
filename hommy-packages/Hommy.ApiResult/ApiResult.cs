using System;
using System.Threading.Tasks;
using Hommy.ResultModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Hommy.ApiResult
{
    public class ApiResult : ActionResult
    {
        public ResultBase Value { get; }

        public ApiResult(ResultBase value)
        {
            Value = value;
        }

        public static implicit operator ApiResult(ResultBase value)
        {
            return new ApiResult(value);
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            await context.HttpContext.RequestServices.GetRequiredService<IActionResultExecutor<ApiResult>>().ExecuteAsync(context, this);
        }
    }

    public class ApiResultExecutor : IActionResultExecutor<ApiResult>
    {
        public virtual async Task ExecuteAsync(ActionContext context, ApiResult result)
        {
            ActionResult actionResult;

            var statusCode = result.Value.GetStatusCode();

            if (result.Value.IsSuccess)
            {
                if(result.Value is IDataResult dataResult)
                {
                    actionResult = new ObjectResult(dataResult.GetData())
                    {
                        StatusCode = statusCode
                    };
                } 
                else
                {
                    actionResult = new StatusCodeResult(statusCode);
                }
            }
            else
            {
                actionResult = new ObjectResult(result.Value.Failure)
                {
                    StatusCode = statusCode
                };
            }

            await actionResult.ExecuteResultAsync(context);
        }
    }
}
