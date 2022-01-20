namespace ApiService
{

    public interface IApiResponse
    {

        #region methods

        string? Status
        {
            get;
            set;
        }

        int HttpCode
        {
            get;
            set;
        }

        bool Success
        {
            get;
            set;
        }

        #endregion methods

        #region methods

        bool SetHttpCode(int httpCode);

        bool SetIsSuccess(bool Success);

        bool SetStatus(string status);

        #endregion methods

    }

}