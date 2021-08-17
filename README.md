# Etherium On Umbraco 9 and docker!

This is a POC project to follow up on Umbraco 9 development on linux and how its running on docker.
I've imported the HTML5up! Etherium template into Umbraco.

Currently the docker is setup for development only.

Findings:
 - its crazy fast compared to umbraco 8
 - the dependency on MSSQL is still a cons, specially since MSSQL is the database that requires the most resources from a server, and it's not great for docker also
 - uSync has some bugs, but it's usable
 - there are still some bugs in Umbraco 9 but you can workaround them
 - working with the dependency injection is jsut a breeze for .net developers used to common asp.net core patterns


## Running

Just `make up`. You might need to run it a second time, since the MSSQL takes some time to setup for the first time and it might prevent umbraco from booting up, if that happens, just stop everything and spin it up again. In the first run of the database, you might want to open a second terminal and `make import` to create the database that umbraco will need (this is necessary because the oficial mssql docker don't offer a way to create a database on startup....)

uSync might take care of everything, but if the home page won't load (with view errors) try to reimport the Views, set the views in the content types and resave the nodes in the content tab.

License MIT.