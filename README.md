# C# .NET Core API Tennis

Simple API made in .NET Core 6.0 to return tennis player data.

### How do I get this thing to work?

 1. Clone repo on your favorite computer
 2. Open solution with Visual Studio
 3. Run the application

In the development environment, Swagger UI will display the 4 different endpoints available:
* **/api/Player/GetPlayerList** *-> Returns the list of players*
* **/api/Player/GetPlayerListByRank** *-> Returns the list of players ordered by rank (Task n°1)*
* **/api/Player/GetPlayerId** *-> Returns a specific player with id (Task n°2)*
	* id *(integer parameter)*
* **/api/Player/GetPlayerGlobalStat** *-> Returns a collection of data as GlobalStat object (Task n°3)*

The player list is available / editable as a JSON file in **Data/headtohead.json**

### Where can I find this online?

This API is available at https://tennisappservice.azurewebsites.net/ with the same endpoints as above

Have fun!
