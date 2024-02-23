using System.Text;

namespace DiabeCare.Utilities
{
    public class HttpClientFactory : IDisposable
    {
        #region Objects
        public HttpClient? client;
        #endregion

        public HttpClientFactory(string baseUrl)
        {
            client = new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    var auth = sender?.Headers?.Authorization;
                    return true;
                },

            }, false);

            client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<HttpResponseMessage> GetAsync(string controllerName)
        {
            HttpResponseMessage? result = null;
            try
            {
                var message = new HttpRequestMessage(HttpMethod.Get, controllerName);
                client.DefaultRequestHeaders.Add("x-app-id", "f3b183b2");
                client.DefaultRequestHeaders.Add("x-app-key", "c867026f03710c309835b5b2d254e4dc");
                result = await client.SendAsync(message);
                result.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                client.DefaultRequestHeaders.Add("x-app-id", "f3b183b2");
                client.DefaultRequestHeaders.Add("x-app-key", "c867026f03710c309835b5b2d254e4dc");
                return await client.GetAsync(controllerName);
            }
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> GetXmlAsync(string controllerName)
        {
            HttpResponseMessage? result = null;
            try
            {
                var message = new HttpRequestMessage(HttpMethod.Get, controllerName);
                result = await client.SendAsync(message);
                result.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                return await client.GetAsync(controllerName);
            }
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> PostAsync(string controllerName, string srlzRequest)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, new StringContent(srlzRequest, Encoding.UTF8, "application/json").ToString());
            message.Headers.Add("x-app-id", "f3b183b2");
            message.Headers.Add("x-app-key", "c867026f03710c309835b5b2d254e4dc");
            var result = await client.SendAsync(message);
            result.EnsureSuccessStatusCode();
            return result.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            client = null;
            GC.Collect();
        }
    }
}
