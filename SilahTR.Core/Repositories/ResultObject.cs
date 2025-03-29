namespace SilahTR.Core.Repositories
{
    public class ResultObject<T>
    {
        public T Data { get; }
        public int Code { get; init; }
        public string Message { get; init; }

        internal ResultObject(T data, int code, string message)
        {
            Data = data;
            Code = code;
            Message = message;
        }

        internal ResultObject(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public static ResultObject<T> Success(T data, int code = default, string message = default)
        {
            return new ResultObject<T>(data, code, message);
        }

        public static ResultObject<T> Failure(int code, string error)
        {
            return new ResultObject<T>(code, error);
        }
    }
}