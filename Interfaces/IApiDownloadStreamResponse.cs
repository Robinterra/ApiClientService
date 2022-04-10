namespace ApiService
{

    public interface IApiDownloadStreamResponse : IApiResponse
    {

        #region methods

        bool SetStream(Stream stream);

        bool SetContentType(string contentType);

        #endregion methods

    }

}