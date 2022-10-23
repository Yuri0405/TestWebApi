# TestWebApi
Before start project go to solution explorer copy full path of ClientsDataFiles folder to get right path of customers data on your machine.
Then go to appsettings.json and find property "ClientDataFolder" and replace path. Now project ready to use.
http://localhost:5000/swagger - for using SwaggerUI
http://localhost:5000/api/clients?phonenumber=[phonenumber] - GET request for getting clients by phone
http://localhost:5000/api/clients - Send POST request with JSON body to this endpoint for record new customer 
