using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RadioGarden.NET.Models.Converters;

namespace RadioGarden.NET.Models.Helpers
{
    /// <summary>
    /// Provides extension methods for the <see cref="HttpClient"/> class.
    /// </summary>
    internal static class HttpClientExtensions
    {
        /// <summary>
        /// A static instance of <see cref="JsonSerializerOptions"/> configured with custom converters.
        /// </summary>
        private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        {
            Converters = { new GeoConverter() }
        };

        /// <summary>
        /// Sends an HTTP GET request and deserializes the JSON response content to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to which the JSON response content is deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/> instance used to send the request.</param>
        /// <param name="requestMessage">The <see cref="HttpRequestMessage"/> representing the HTTP GET request.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the deserialized object of type <typeparamref name="T"/> if the request is successful; otherwise, <c>null</c>.
        /// </returns>
        internal static async Task<T?> SendGetJsonAsync<T>(this HttpClient httpClient,
            HttpRequestMessage requestMessage)
            where T : class
        {
            var response = await httpClient.SendAsync(requestMessage);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(json, SerializerOptions);
            }

            return null;
        }
    }
}