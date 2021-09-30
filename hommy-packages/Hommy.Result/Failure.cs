using System;
using System.Linq;

namespace Hommy.ResultModel
{
    public abstract class Failure
    {
        public string Message { get; }

        public Failure(string message)
        {
            Message = message;
        }
    }

    public class BadRequestFailure : Failure
    {
        public BadRequestFailure(string message) : base(message)
        {
        }
    }

    public class NotFoundFailure : Failure
    {
        public NotFoundFailure(string message) : base(message)
        {
        }
    }

    public class UnauthorizedFailure : Failure
    {
        public UnauthorizedFailure(string message) : base(message)
        {
        }
    }

    public class ForbiddenFailure : Failure
    {
        public ForbiddenFailure(string message) : base(message)
        {
        }
    }

    public class ExceptionFailure : Failure
    {
        public string StackTrace { get; set; }

        public ExceptionFailure(Exception exception) : base(exception.Message)
        {
            StackTrace = exception.StackTrace;
        }

        public ExceptionFailure(string message) : base(message)
        {
        }
    }

    public class ValidationFailure : Failure
    {
        public ValidationError[] ValidationErrors { get; }

        public ValidationFailure(ValidationError[] validationErrors, string message = "Validation Error")
            : base(message)
        {
            if (validationErrors == null || !validationErrors.Any())
            {
                throw new ArgumentException(nameof(validationErrors));
            }

            ValidationErrors = validationErrors;
        }

        public ValidationFailure(ValidationError validationError, string message = "Validation Error")
            : this(new[] { validationError }, message)
        {

        }
    }
}