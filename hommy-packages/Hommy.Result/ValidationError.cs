namespace Hommy.ResultModel
{
    /// <summary>
    /// Validation error message model
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Field
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        public ValidationError()
        { 
        }

        public ValidationError(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}