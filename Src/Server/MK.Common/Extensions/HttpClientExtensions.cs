using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MK.Common.Exceptions;
using apcurium.MK.Common.Diagnostic;
using apcurium.MK.Common.Http.Response;

namespace apcurium.MK.Common.Extensions
{
	public static class HttpClientExtensions
    {
        public static Task<T> DeleteAsync<T>(this HttpClient client, IReturn<T> request, ILogger logger = null)
        {
            var url = request.GetUrlFromRoute();
            return client.DeleteAsync<T>(url, logger: logger);
        }

        public static Task<T> PostAsync<T>(this HttpClient client, IReturn<T> request, ILogger logger = null)
        {
            var url = request.GetUrlFromRoute();

            return client.PostAsync<T>(url, request, logger: logger);
        }

        public static Task<T> GetAsync<T>(this HttpClient client, IReturn<T> request, ILogger logger = null)
        {
            var url = request.GetUrlFromRoute(true);

            return client.GetAsync<T>(url, logger: logger);
        }

        private static string GetForEndpointIfNeeded(this HttpClient client, string url)
        {
            if (url.StartsWith("http") || client.BaseAddress == null)
            {
                return url;
            }

            var currentRelativeUrl = client.BaseAddress.LocalPath;


            if (currentRelativeUrl.EndsWith("/"))
            {
                return url.StartsWith("/")
                    ? currentRelativeUrl + url.Remove(0, 1)
                    : currentRelativeUrl + url;
            }

            return url.StartsWith("/")
                ? currentRelativeUrl + url
                    : "{0}/{1}".InvariantCultureFormat(currentRelativeUrl, url);
        }

        public static Task<T> DeleteAsync<T>(this HttpClient client,
            string url,
            Action<HttpResponseMessage> onSuccess = null,
            Action<HttpResponseMessage> onError = null,
            ILogger logger = null)
        {
            return Task.Run(() => client.DeleteAsync(client.GetForEndpointIfNeeded(url)).HandleResult<T>(onSuccess, onError, logger));
        }

	    public static Task<HttpResponseMessage> PostAndGetHttpResponseMessage(this HttpClient client, string url, object content)
	    {
            var body = new StringContent(content.ToJson(), Encoding.UTF8, "application/json");

            var relativeUrl = client.GetForEndpointIfNeeded(url);

            return client.PostAsync(relativeUrl, body);
	    }

        public static Task<TResult> PostAsync<TResult>(this HttpClient client,
            string url,
            object content,
            Action<HttpResponseMessage> onSuccess = null,
            Action<HttpResponseMessage> onError = null,
            ILogger logger = null)
        {
            return Task.Run(() => InnerPostAsync<TResult>(client, url, content, onSuccess, onError, logger));
        }

        public static Task<TResult> GetAsync<TResult>(this HttpClient client,
            string url,
            Action<HttpResponseMessage> onSuccess = null,
            Action<HttpResponseMessage> onError = null,
            ILogger logger = null)
        {
            return Task.Run(() => client.GetAsync(client.GetForEndpointIfNeeded(url)).HandleResult<TResult>(onSuccess, onError, logger));
        }

        private static async Task<TResult> InnerPostAsync<TResult>(HttpClient client, string url, object content, Action<HttpResponseMessage> onSuccess, Action<HttpResponseMessage> onError, ILogger logger)
	    {
			var body = new StringContent(content.ToJson(), Encoding.UTF8, "application/json");

	        var relativeUrl = client.GetForEndpointIfNeeded(url);

            return await client.PostAsync(relativeUrl, body).HandleResult<TResult>(onSuccess, onError, logger);
	    }

	    public static Task<TResult> PutAsync<TResult>(this HttpClient client, IReturn<TResult> content, Action<HttpResponseMessage> onSuccess = null, Action<HttpResponseMessage> onError = null, ILogger logger = null)
	    {
	        return PutAsync<TResult>(client, content.GetUrlFromRoute(), content, onSuccess, onError, logger);
	    } 

	    public static Task<TResult> PutAsync<TResult>(this HttpClient client,
            string url,
            object content,
            Action<HttpResponseMessage> onSuccess = null,
            Action<HttpResponseMessage> onError = null,
            ILogger logger = null)
        {
            return Task.Run(async () =>
            {
                var body = new StringContent(content.ToJson(), Encoding.UTF8, "application/json");

                return await client.PutAsync(client.GetForEndpointIfNeeded(url), body).HandleResult<TResult>(onSuccess, onError, logger);
            });
        }

        private static async Task<TResult> HandleResult<TResult>(this Task<HttpResponseMessage> response, Action<HttpResponseMessage> onSuccess, Action<HttpResponseMessage> onError, ILogger logger)
        {
            var result = await response;

            await result.HandleResultInternal(onSuccess, onError, logger);

            var jsonContent = await result.Content.ReadAsStringAsync();

            return jsonContent.FromJsonSafe<TResult>();
        }

        private static async Task HandleResultInternal(this HttpResponseMessage result, Action<HttpResponseMessage> onSuccess, Action<HttpResponseMessage> onError, ILogger logger)
        {
            if (!result.IsSuccessStatusCode)
            {
                logger.Maybe(x => x.LogMessage(string.Format("{0} {1} ({2} {3})", result.RequestMessage.Method, result.RequestMessage.RequestUri, (int)result.StatusCode, result.ReasonPhrase)));

                if (onError != null)
                {
                    onError(result);
                }

                var body = await result.Content.ReadAsStringAsync();

                ErrorResponse errorResponse;
                try
                {
                    errorResponse = body.FromJsonSafe<ErrorResponse>();
                }
                catch
                {
                    errorResponse = null;
                }

                if (errorResponse != null && errorResponse.ResponseStatus != null)
                {
                    throw new WebServiceException(errorResponse.ResponseStatus.Message.HasValueTrimmed() 
                        ? errorResponse.ResponseStatus.Message 
                        : errorResponse.ResponseStatus.ErrorCode) 
                    {
                        StatusCode = (int)result.StatusCode,
                        StatusDescription = result.ReasonPhrase,
                        ResponseBody = body
                    };
                }
                else
                {
                    throw new WebServiceException(result.ReasonPhrase) 
                    {
                        StatusCode = (int)result.StatusCode,
                        StatusDescription = result.ReasonPhrase,
                        ResponseBody = body
                    };
                }
            }

            if (onSuccess != null)
            {
                onSuccess(result);
            }
        }
    }
}

