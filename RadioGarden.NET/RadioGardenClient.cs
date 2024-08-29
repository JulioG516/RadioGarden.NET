using System;
using System.Text.Json;
using System.Threading.Tasks;
using RadioGarden.NET.Models;
using RadioGarden.NET.Models.Converters;
using RestSharp;
using RestSharp.Serializers.Json;

namespace RadioGarden.NET
{
    /// <summary>
    /// The client for interacting with the Radio Garden API.
    /// </summary>
    public class RadioGardenClient
    {
        private readonly RestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioGardenClient"/> class.
        /// </summary>
        public RadioGardenClient()
        {
            // ConfigureMessageHandler = handler => new HttpClientHandler(),

            var restOptions = new RestClientOptions
            {
                BaseUrl = new Uri("https://radio.garden/api"),
            };

            var serializerOptions = new JsonSerializerOptions()
            {
                Converters = { new GeoConverter() }
            };


            _restClient = new RestClient(restOptions,
                configureSerialization: s => s.UseSystemTextJson(serializerOptions)
            );
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
            var request = new RestRequest("ara/content/places");

            var response = await _restClient.GetAsync<PlacesResponse>(request);
            return response;
        }

        /// <summary>
        /// Retrieves places with registered radio stations.
        /// </summary>
        /// <returns>
        /// An <see cref="PlacesResponse"/> object containing the list of places with radio stations, or null if the request fails.
        /// </returns>
        public PlacesResponse? GetAllPlaces()
        {
            var request = new RestRequest("ara/content/places");

            var response = _restClient.Get<PlacesResponse>(request);
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

            var request = new RestRequest($"ara/content/page/{placeId}/channels");
            var response = await _restClient.GetAsync<PlaceChannelsResponse>(request);
            return response;
        }

        /// <summary>
        /// Retrieves the list of registered radio stations for a specified place.
        /// </summary>
        /// <param name="placeId">The unique identifier of the place.</param>
        /// <returns>
        /// A <see cref="PlaceChannelsResponse"/> object containing the list of radio channels for the specified place, or null if the request fails.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="placeId"/> is null or empty.</exception>
        public PlaceChannelsResponse? GetPlaceChannels(string placeId)
        {
            if (string.IsNullOrEmpty(placeId))
                throw new ArgumentNullException(nameof(placeId), "Parameter Id can't be null or empty.");

            var request = new RestRequest($"ara/content/page/{placeId}/channels");
            var response = _restClient.Get<PlaceChannelsResponse>(request);
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
            var request = new RestRequest($"ara/content/channel/{channelId}");
            var response = await _restClient.GetAsync<ChannelDetailsResponse?>(request);
            return response;
        }

        /// <summary>
        /// Retrieves detailed information about a specific radio channel.
        /// </summary>
        /// <param name="channelId">The ID of the radio channel to retrieve details for.</param>
        /// <returns>
        /// A <see cref="Task{ChannelDetailsResponse}"/> representing the asynchronous operation, 
        /// with a <see cref="ChannelDetailsResponse"/> containing the channel details, or null if the request fails.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="channelId"/> is null or empty.</exception>
        public ChannelDetailsResponse? GetChannelDetails(string channelId)
        {
            if (string.IsNullOrEmpty(channelId))
                throw new ArgumentNullException(nameof(channelId), "channelId can't be null or empty.");
            var request = new RestRequest($"ara/content/channel/{channelId}");
            var response = _restClient.Get<ChannelDetailsResponse?>(request);
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

            var request = new RestRequest($"ara/content/listen/{channelId}/channel.mp3");
            var response = await _restClient.HeadAsync(request);

            return response.IsSuccessful
                   && response.ResponseUri != null
                ? response.ResponseUri.ToString()
                : null;
        }

        /// <summary>
        /// Retrieves the broadcast stream URL for a specific radio channel.
        /// </summary>
        /// <param name="channelId">The ID of the radio channel.</param>
        /// <returns>
        /// A <see cref="Task{String}"/> representing the asynchronous operation, 
        /// with a string containing the broadcast stream URL if successful, or an empty string if the request fails.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="channelId"/> is null or empty.</exception>
        public string? GetChannelStreamUrl(string channelId)
        {
            if (string.IsNullOrEmpty(channelId))
                throw new ArgumentNullException(nameof(channelId), "channelId can't be null or empty.");

            var request = new RestRequest($"ara/content/listen/{channelId}/channel.mp3");
            var response = _restClient.Head(request);

            return response.IsSuccessful
                   && response.ResponseUri != null
                ? response.ResponseUri.ToString()
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

            var request = new RestRequest($"search?q={query}");
            var response = await _restClient.GetAsync<QueryResponse>(request);
            return response;
        }


        /// <summary>
        /// Search countries, places, and radio stations.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <returns>
        /// A <see cref="Task{QueryResponse}"/> representing the asynchronous operation, 
        /// with a <see cref="QueryResponse"/> containing the search results, or null if the request fails.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="query"/> is null or empty.</exception>
        public QueryResponse? Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException(nameof(query), "Query can't be null or empty.");

            var request = new RestRequest($"search?q={query}");
            var response = _restClient.Get<QueryResponse>(request);
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
            var request = new RestRequest("geo");
            var response = await _restClient.GetAsync<GeoLocation>(request);
            return response;
        }
        
        /// <summary>
        /// Retrieves the client's geolocation.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{GeoLocation}"/> representing the asynchronous operation, 
        /// with an <see cref="GeoLocation"/> object containing the client's geolocation data, or null if the request fails.
        /// </returns>
        public GeoLocation? GetClientGeoLocation()
        {
            var request = new RestRequest("geo");
            var response = _restClient.Get<GeoLocation>(request);
            return response;
        }
        
        
        #endregion
    }
}