using Hommy.ResultModel;
using Microsoft.AspNetCore.Http;

namespace Hommy.ApiResult
{
    public static class ApiResultResultExtensions
    {
        public static int GetStatusCode(this ResultBase result)
        {
            if (result.IsSuccess)
            {
                return StatusCodes.Status200OK;
            }

            switch (result.Failure)
            {
                case ExceptionFailure _:
                    return StatusCodes.Status500InternalServerError;
                case UnauthorizedFailure _:
                    return StatusCodes.Status401Unauthorized;
                case ForbiddenFailure _:
                    return StatusCodes.Status403Forbidden;
                case NotFoundFailure _:
                    return StatusCodes.Status404NotFound;
                default:
                    return StatusCodes.Status400BadRequest;
            }
        }
    }
}
