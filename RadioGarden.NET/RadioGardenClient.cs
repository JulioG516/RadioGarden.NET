using System;
using System.Net.Http;
using System.Threading.Tasks;
using RadioGarden.NET.Models;
using RadioGarden.NET.Models.Helpers;

namespace RadioGarden.NET
{
    /// <summary>
    /// The client for interacting with the Radio Garden API.
    /// </summary>
    public class RadioGardenClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioGardenClient"/> class.
        /// </summary>
        public RadioGardenClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://radio.garden/api"),
            };
        }

        #region Places

        /// <summary>
        /// Retrieves places with registered radio stations asynchronously.
        /// </summary>
        /// <returns>
        /// An <see cref="PlacesResponse"/> object containing the list of places with radio stations, or null if the request fails.
        /// </returns>
        public async Task<PlacesResponse?> GetAllPlacesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "/api/ara/content/places");

            var response = await _httpClient.SendGetJsonAsync<PlacesResponse>(request);

            return response;
        }


        /// <summary>
        /// Retrieves the list of registered radio stations for a specified place asynchronously.
        /// </summary>
        /// <param name="placeId">The unique identifier of the place.</param>
        /// <returns>
        /// A <see cref="PlaceChannelsResponse"/> object containing the list of radio channels for the specified place, or null if the request fails.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="placeId"/> is null or empty.</exception>
        public async Task<PlaceChannelsResponse?> GetPlaceChannelsAsync(string placeId)
        {
            if (string.IsNullOrEmpty(placeId))
                throw new ArgumentException("Parameter Id can't be null or empty.");

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"api/ara/content/page/{placeId}/channels");
            var response = await _httpClient.SendGetJsonAsync<PlaceChannelsResponse>(request);
            return response;
        }

        #endregion

        #region Channels

        /// <summary>
        /// Retrieves detailed information about a specific radio channel asynchronously.
        /// </summary>
        /// <param name="channelId">The ID of the radio channel to retrieve details for.</param>
        /// <returns>
        /// A <see cref="Task{ChannelDetailsResponse}"/> representing the asynchronous operation, 
        /// with a <see cref="ChannelDetailsResponse"/> containing the channel details, or null if the request fails.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="channelId"/> is null or empty.</exception>
        public async Task<ChannelDetailsResponse?> GetChannelDetailsAsync(string channelId)
        {
            if (string.IsNullOrEmpty(channelId))
                throw new ArgumentNullException(nameof(channelId), "channelId can't be null or empty.");

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"api/ara/content/channel/{channelId}");
            var response = await _httpClient.SendGetJsonAsync<ChannelDetailsResponse>(request);
            return response;
        }


        /// <summary>
        /// Retrieves the broadcast stream URL for a specific radio channel asynchronously.
        /// </summary>
        /// <param name="channelId">The ID of the radio channel.</param>
        /// <returns>
        /// A <see cref="Task{String}"/> representing the asynchronous operation, 
        /// with a string containing the broadcast stream URL if successful, or an empty string if the request fails.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="channelId"/> is null or empty.</exception>
        public async Task<string?> GetChannelStreamUrlAsync(string channelId)
        {
            if (string.IsNullOrEmpty(channelId))
                throw new ArgumentNullException(nameof(channelId), "channelId can't be null or empty.");

            var request = new HttpRequestMessage(HttpMethod.Head,
                $"api/ara/content/listen/{channelId}/channel.mp3");

            var response = await _httpClient.SendAsync(request);

            return response.IsSuccessStatusCode &&
                   response.RequestMessage?.RequestUri != null
                ? response.RequestMessage.RequestUri.ToString()
                : null;
        }

        #endregion

        #region Search

        /// <summary>
        /// Search countries, places, and radio stations asynchronously.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <returns>
        /// A <see cref="Task{QueryResponse}"/> representing the asynchronous operation, 
        /// with a <see cref="QueryResponse"/> containing the search results, or null if the request fails.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="query"/> is null or empty.</exception>
        public async Task<QueryResponse?> SearchAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException(nameof(query), "Query can't be null or empty.");

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"api/search?q={query}");
            var response = await _httpClient.SendGetJsonAsync<QueryResponse>(request);
            return response;
        }

        #endregion

        #region Geo

        /// <summary>
        /// Retrieves the client's geolocation asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{GeoLocation}"/> representing the asynchronous operation, 
        /// with an <see cref="GeoLocation"/> object containing the client's geolocation data, or null if the request fails.
        /// </returns>
        public async Task<GeoLocation?> GetClientGeoLocationAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "api/geo");
            var response = await _httpClient.SendGetJsonAsync<GeoLocation>(request);
            return response;
        }

        #endregion
    }
}