using System.Net;
using System.Text;
using System.Text.Json;

namespace ApiService
{
    public class FakeApiClient : IApiClient
    {

        #region vars

        public ApiDelegate? DeleteDelegate;

        public ApiDelegate? GetDelegate;

        public ApiDelegate? PostDelegate;

        public ApiDelegate? PutDelegate;

        private string baseAdress;

        private string apiPath;

        #endregion vars

        #region ctor

        public FakeApiClient(string baseadress, string apiPath, ApiDelegate? get = null, ApiDelegate? post = null, ApiDelegate? put = null, ApiDelegate? delete = null)
        {
            this.baseAdress = baseadress;
            this.apiPath = apiPath;
            this.GetDelegate = get;
            this.DeleteDelegate = delete;
            this.PostDelegate = post;
            this.PutDelegate = put;
        }

        #endregion ctor

        #region delegates

        public delegate Task<FakeApiResponse> ApiDelegate(FakeApiRequest request);

        #endregion delegates

        #region methods

        private TResponse SetToResponse<TResponse>(TResponse result, bool isSuccess, HttpStatusCode statusCode)
        {
            if (result is not IApiResponse apiResponse) return result;

            apiResponse.SetHttpCode((int)statusCode);

            apiResponse.SetIsSuccess(isSuccess);

            return result;
        }

        public async Task<TResponse?> DeleteAsync<TResponse>(params object[] header) where TResponse : new()
        {
            if (this.DeleteDelegate is null) return default;

            string fullUrl = $"{baseAdress}{apiPath}/{string.Join('/', header)}";

            FakeApiResponse response = await this.DeleteDelegate(new (baseAdress, apiPath, fullUrl, header));
            if (response.FromBody is null) return default;
            if (response.FromBody is not TResponse tr) throw new Exception("response Body is not expectet TResponse");

            return this.SetToResponse(tr, response.IsSuccessStatusCode, response.HttpCode);
        }

        public async Task<TResponse?> GetAsync<TResponse>(params object[] header) where TResponse : new()
        {
            if (this.GetDelegate is null) return default;

            string fullUrl = $"{baseAdress}{apiPath}/{string.Join('/', header)}";

            FakeApiResponse response = await this.GetDelegate(new (baseAdress, apiPath, fullUrl, header));
            if (response.FromBody is null) return default;
            if (response.FromBody is not TResponse tr) throw new Exception("response Body is not expectet TResponse");

            return this.SetToResponse(tr, response.IsSuccessStatusCode, response.HttpCode);
        }

        public async Task<TResponse?> PostAsync<TResponse, TRequest>(TRequest data, string route) where TResponse : new()
        {
            if (this.PostDelegate is null) return default;

            string fullUrl = $"{baseAdress}{apiPath}/{route}";

            FakeApiResponse response = await this.PostDelegate(new (baseAdress, apiPath, fullUrl, body: data));
            if (response.FromBody is null) return default;
            if (response.FromBody is not TResponse tr) throw new Exception("response Body is not expectet TResponse");

            return this.SetToResponse(tr, response.IsSuccessStatusCode, response.HttpCode);
        }

        public async Task<TResponse?> PostAsync<TResponse>(string route) where TResponse : new()
        {
            if (this.PostDelegate is null) return default;

            string fullUrl = $"{baseAdress}{apiPath}/{route}";

            FakeApiResponse response = await this.PostDelegate(new (baseAdress, apiPath, fullUrl));
            if (response.FromBody is null) return default;
            if (response.FromBody is not TResponse tr) throw new Exception("response Body is not expectet TResponse");

            return this.SetToResponse(tr, response.IsSuccessStatusCode, response.HttpCode);
        }

        public async Task<TResponse?> PutAsync<TResponse, TRequest>(TRequest data, string route) where TResponse : new()
        {
            if (this.PutDelegate is null) return default;

            string fullUrl = $"{baseAdress}{apiPath}/{route}";

            FakeApiResponse response = await this.PutDelegate(new (baseAdress, apiPath, fullUrl, body: data));
            if (response.FromBody is null) return default;
            if (response.FromBody is not TResponse tr) throw new Exception("response Body is not expectet TResponse");

            return this.SetToResponse(tr, response.IsSuccessStatusCode, response.HttpCode);
        }

        #endregion methods

    }
}
// -- [EOF] --