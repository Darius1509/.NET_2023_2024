namespace ECommerceApp.Domain.Common
{
    public class Result<T> where T : class
    {
        private Result(bool isSuccess, T value, string errorMessage)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccess { get; }
        public T Value { get; }
        public string ErrorMessage { get; }

        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, null!);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, null!, errorMessage);
        }
    }
}
