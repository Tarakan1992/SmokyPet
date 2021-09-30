using Hommy.ResultModel;
using Microsoft.AspNetCore.Http;

namespace Hommy.ApiResult
{
    public static class ApiResultResultExtensions
    {
        public static int GetStatusCode(this ResultBase result) => result switch
        {
            { IsSuccess: true } => StatusCodes.Status200OK,
            { Failure: ExceptionFailure } => StatusCodes.Status500InternalServerError,
            { Failure: UnauthorizedFailure } => StatusCodes.Status401Unauthorized,
            { Failure: ForbiddenFailure } => StatusCodes.Status403Forbidden,
            { Failure: NotFoundFailure } => StatusCodes.Status404NotFound,
            { Failure: { } } => StatusCodes.Status400BadRequest,
            _ => throw new System.NotImplementedException(),
        };
    }
}
