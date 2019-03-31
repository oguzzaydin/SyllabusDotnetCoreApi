using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DPA.IntegrationTest
{
    public class Check
    {
        public static async Task<TResultType> ResultAsync<TResultType>(HttpResponseMessage response, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            await EnsureNotErrorResultAsync(response);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AsyncResult<TResultType>>(content).Result;
        }
        public static async Task<TResultType> Result<TResultType>(HttpResponseMessage response, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            await EnsureNotErrorResultAsync(response);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResultType>(content);
        }
        public static async Task<byte[]> ResultByte(HttpResponseMessage response, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            await EnsureNotErrorResultAsync(response);
            var content = await response.Content.ReadAsByteArrayAsync();
            return content;
        }
        public static async Task EnsureNotErrorResultAsync(HttpResponseMessage response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<IntegrationServiceResult>(
                        (await response.Content.ReadAsStringAsync()).Remove(0, 1));
                if (result != null && !result.IsSuccess)
                    throw new Exception(result.Errors.First().Description);
            }
        }

    }
}
