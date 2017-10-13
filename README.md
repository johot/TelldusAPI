# Telldus API
A simple .NET Framework + .NET Core (by using .NET standard) library for controlling your Telldus Tellstick via the Telldus Live! API.

_This is an early version that can turn lights on, off and dim them. More functions might be added in the future if people are interested in this library, let me know_ 😊 _(or do a pull request)._

## Usage

### Before use
First get your API keys by going to <https://api.telldus.com/keys/index>, here you can also get an overview of the API.

### Authorize to get hold of you access tokens
The Telldus API uses OAuth 1.0a so you first need get hold of an access token and access token secret. You can read more about how it works [here](https://github.com/johot/TinyOAuth1).

#### Visit authorization url

```cs
var telldusClient = new TelldusClient(_consumerKey, _consumerSecretKey);

var authorizationUrl = await telldusClient.GetAuthorizationUrlAsync();

// This can be done in many different ways, somehow redirect your user to the authorization url
Process.Start(authorizationUrl);

// Wait for user to finish authorization on the telldus webpage then go to next step
```

#### Get your access tokens
This must be done after the user has visited the authorization page (sample above) or it will not work.

```cs
var accessTokens = await telldusClient.FinalizeAuthorizationAsync();

// Now you want to save these tokens somewhere so the user doesn't have to do this every time
```

#### Authorize

```cs
telldusClient.Authorize(accessTokens.AccessToken, accessTokens.AccessTokenSecret);

// Now you can start using the methods of the TelldusClient
```

### Sample usage

```cs
// Get all the devices for your account
var devices = await telldusClient.GetDevicesAsync();

var firstDevice = devices.First();

// Turn lamp on
await firstDevice.TurnOnAsync();

// Turn lamp off
await firstDevice.TurnOffAsync();

// Dim lamp (if available) to 50%
await firstDevice.DimAsync(0.5);
```

Thats it, enjoy and let me know if you have any feedback, had use for this library and so on 😄!
		

