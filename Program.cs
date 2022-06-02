using System;
using VRChat.API.Api;
using VRChat.API.Client;
using VRChat.API.Model;


// Authentication credentials
Configuration Config = new Configuration();
Config.Username = "username";
Config.Password = "password";

// Create instances of API's we'll need
AuthenticationApi AuthApi = new AuthenticationApi(Config);
UsersApi UserApi = new UsersApi(Config);
WorldsApi WorldApi = new WorldsApi(Config);

try
{
    // Calling "GetCurrentUser(Async)" logs you in if you are not already logged in.
    CurrentUser CurrentUser = await AuthApi.GetCurrentUserAsync();
    Console.WriteLine("Logged in as {0}, Current Avatar {1}", CurrentUser.DisplayName, CurrentUser.CurrentAvatar);

    User OtherUser = await UserApi.GetUserAsync("usr_c1644b5b-3ca4-45b4-97c6-a2a0de70d469");
    Console.WriteLine("Found user {0}, joined {1}", OtherUser.DisplayName, OtherUser.DateJoined);

    World World = await WorldApi.GetWorldAsync("wrld_ba913a96-fac4-4048-a062-9aa5db092812");
    Console.WriteLine("Found world {0}, visits: {1}", World.Name, World.Visits);
}
catch (ApiException e)
{
    Console.WriteLine("Exception when calling API: {0}", e.Message);
    Console.WriteLine("Status Code: {0}", e.ErrorCode);
    Console.WriteLine(e.ToString());
}
