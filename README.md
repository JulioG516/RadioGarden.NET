# Radio Garden API .NET Library

This .NET library provides an interface to interact with the [Radio Garden](https://radio.garden/) API, allowing you to retrieve information about radio channels, places, and geolocation data.

## Features

- Retrieve detailed information about radio channels.
- Get the list of registered radio stations for a specific place.
- Retrieve the stream url from a specific radio channel.
- Search for radio channels by query.
- Retrieve the client's geolocation.
- Supports both asynchronous and synchronous operations.


## Usage

First, initialize the RadioGardenClient:
```
var client = new RadioGardenClient();
```

### Get all places
```
var places = await client.GetAllPlacesAsync();
```

### Retrieves the list of registered radio stations for a specified place.
```
var channels = await client.GetPlaceChannelsAsync("yaXwoZ5Z");
```

### Retrieves detailed information about a specific radio channel
```
var channels = await client.GetChannelDetailsAsync("F5Rrw1YB");
```

### Retrieves the broadcast stream URL for a specific radio channel
```
var streamUrl = await client.GetChannelStreamUrlAsync("F5Rrw1YB");
```


### Get's user location
```
var local = await radio.GetClientGeoLocationAsync();
```


### Search countries, places, and radio stations.
```
var query = await radio.SearchAsync("Airport");
```






