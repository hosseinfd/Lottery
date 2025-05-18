namespace Domain.Common
{
    public class Result<TData>
    {
        public Result()
        {
            
        }
        protected Result(bool isSuccess, TData? data = default, List<ValidationItem?> errors = default)
        {
            IsSuccess = isSuccess;
            Data = data;
            Errors = errors;
        }

        protected Result(bool isSuccess, List<ValidationItem?> errors = default)
        {
            Data = default;
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public TData? Data { get; set; }
        public List<ValidationItem?> Errors { get; set; }
        public bool IsSuccess { get; set; }


        public static Result<TData> Succeed(TData data, bool isSuccess = true)
        {
            return new Result<TData>(isSuccess, data);
        }

        public static Result<object> Succeed()
        {
            return new Result<object>(true, null, null);
        }

        public static Result<object> Failed(List<ValidationItem?> validationItems,object? data = null)
        {
            return new Result<object>(false, data,validationItems);
        }
        public static Result<object> Failed(Exception e)
        {
            return new Result<object>(false, e);
        }
    }

    public class Result : Result<object>
    {
        public Result() : base(true, null, null)
        {
        }

        public new static Result Succeed()
        {
            return new Result();
        }
    }
}