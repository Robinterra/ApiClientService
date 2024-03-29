namespace ApiService
{
    public interface IApiClient
    {

        #region methods

        Task<TResponse?> GetAsync<TResponse>(params object[] header) where TResponse : new();

        Task<TResponse?> PostAsync<TResponse, TRequest>(TRequest data, string route) where TResponse : new();

        Task<TResponse?> PostAsync<TResponse>(string route) where TResponse : new();

        Task<TResponse?> PutAsync<TResponse, TRequest>(TRequest data, string route) where TResponse : new();

        Task<TResponse?> DeleteAsync<TResponse>(params object[] header) where TResponse : new();

        Task<TResponse> UploadFileAsync<TResponse>(List<FileUploadRequest> files, string route) where TResponse : IApiResponse, new();

        #endregion methods

    }
}