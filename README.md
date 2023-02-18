# McServerBot

Discord bot interface for McServerApi

### Environment Variables:

**token**

Discord token acquired from the Discord developer dashboard

**logChannel**

Discord channel id that the bot has access to. Used for logging

**apiUrl**

Internal API Url for accessing the API. Defaults to `http://localhost:8080`

**publicApiUrl**

External API url used to display the connection endpoint to connect to the server, and to generate a download link for resource packs. Default is apiUrl if not specified

If you don't want the full API exposed to the internet, just the GET `/Maps/resources/{ID}` endpoint needs to be accessible.