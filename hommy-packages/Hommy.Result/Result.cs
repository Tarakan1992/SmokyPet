namespace Hommy.ResultModel
{
    public abstract class ResultBase
    {
        public bool IsSuccess => Failure == null;

        public Failure Failure { get; set; }

        protected ResultBase(Failure failure)
        {
            Failure = failure;
        }

        protected ResultBase()
        {
        }

        public virtual object Content => IsSuccess ? null : Failure;
    }

    public class Result : ResultBase
    {

        public Result(Failure failure) : base(failure)
        {

        }

        public Result()
        {
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result<TObject> Success<TObject>(TObject value)
        {
            return new Result<TObject>(value);
        }

        public static Result Fail(Failure failure)
        {
            return new Result(failure);
        }

        public static Result Fail(string message)
        {
            return Fail(new BadRequestFailure(message));
        }

        public static Result NotFound(string message)
        {
            return Fail(new NotFoundFailure(message));
        }

        public static Result Unauthorized(string message)
        {
            return Fail(new UnauthorizedFailure(message));
        }

        public static Result Forbidden(string message)
        {
            return Fail(new ForbiddenFailure(message));
        }

        public static Result ValidationError(ValidationError validationError)
        {
            return Fail(new ValidationFailure(validationError));
        }

        public static Result ValidationError(ValidationError[] validationErrors)
        {
            return Fail(new ValidationFailure(validationErrors));
        }
    }

    public class Result<TObject> : ResultBase
    {
        public TObject Data { get; set; }

        public Result()
        {
        }

        public Result(TObject data)
        {
            Data = data;
        }

        public Result(Failure failure) : base(failure)
        {
        }

        public override object Content => IsSuccess ? Data : Failure;

        public static implicit operator Result<TObject>(TObject value)
        {
            return new Result<TObject>(value);
        }

        public static implicit operator Result<TObject>(Result result)
        {
            return new Result<TObject>(result.Failure);
        }

        public static implicit operator Result(Result<TObject> result)
        {
            return new Result(result.Failure);
        }
    }
}
