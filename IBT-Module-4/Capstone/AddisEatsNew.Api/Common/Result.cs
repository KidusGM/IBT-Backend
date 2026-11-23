namespace AddisEatsNew.Api.Common
{
    public record Error
     (
        string Code,
        String Message,
        int Status

        );

    public class Result<T>

    { 
    
        public T? Value { get; set; }
        public Error? Error { get; set; }
        public bool IsSuccess => Error is null;

        public static Result<T> Ok(T value) => new() { Value = value };

        public static Result<T> Fail(
            string code,
            string message,
            int status) => new()

            {
                Error = new Error(code, message, status)
            };
    }


}
