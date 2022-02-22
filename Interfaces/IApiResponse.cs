namespace ApiService
{

    public interface IApiResponse
    {

        #region methods

        bool SetHttpCode(int httpCode);

        bool SetIsSuccess(bool Success);

        bool SetStatus(string status);

        bool SetException(Exception exception);

        #endregion methods

    }

}