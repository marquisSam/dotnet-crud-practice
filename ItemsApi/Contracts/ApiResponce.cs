namespace ItemsApi.Contracts
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(string message, T data)
        {
            Message = message;
            Data = data;
        }
    }
}