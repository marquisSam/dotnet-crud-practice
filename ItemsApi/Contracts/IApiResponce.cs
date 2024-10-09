namespace ItemsApi.Contracts
{
    public interface IApiResponse<T>
    {
        string Message { get; set; }
        T Data { get; set; }
    }
}