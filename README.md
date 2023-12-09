# C# .NET Core API Tennis

Simple API made in .NET Core 6.0 to return tennis player data.

### How do I get this thing to work?

 1. Clone repo on your favorite computer
 2. Open solution with Visual Studio
 3. Run the application

In the development environment, Swagger UI will display the 3 different endpoints available:
* **/api/Players** GET *-> Returns the list of players sorted and ordered if specified*
	* sort *(optional string parameter) (possible values: "rank")*
	* order *(optional string parameter) (possible values: "asc", "desc")*
* **/api/Player** GET *-> Returns a specific player by id*
	* id *(integer parameter)*
* **/api/GlobalStat** GET *-> Returns a collection of data as GlobalStat object*

The player list is available / editable as a JSON file in **Data/headtohead.json**

Have fun!
