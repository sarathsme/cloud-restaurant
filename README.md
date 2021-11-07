# Cloud Restaurant

#### A simple extendable .NET core + Angular web app to display the menu for a restaurant.


## Overiew

The backend for this app is built using .net core web api and the client side web app is built using Angular. Deployments are managed using docker and docker-compose.

The frontend can only display the menu. It does not have the capability to add/edit menus. To add/edit menus we will have to make use of the REST API. 

## Consuming the REST API

The REST API can be consumed in any of the following ways
1. The export of the postman collection for the API is available in the root of this repository with the name postman-collection.json. This can be imported to your Postman application. Remember to update the value for collection variable with the name ``` HOST_URL ``` to the URL for the REST API before running any of the requests.
2. Go to the relative URL ``` /api/swagger ``` of the website. Here we have documentation as well as the capability to run all the REST API endpoints.

## Important URLs

1. The angular app will be available in the root of the website
2. The REST API will be available in the path ```  /api ```
3. The swagger documentation can be found at ``` /api/swagger ```

## How to lauch the app

### Using docker

#### Prerequisite
Docker and docker-compose must be installed either in a linux OS or the docker-desktop in windows must support WSL2 integration.

#### Steps
1. Clone this repository in your local machine
2. Run ``` docker-compose up -d ``` from inside the repository
3. Go to http://localhost:4201

### Manual setup

#### Prerequisites

1. Mongo DB - 5.0.0
2. dotnet core - 5.0.0
3. nodejs - 14.17.0
4. npm - 6.4.13

#### Steps

1. Add the connection string for Mongo database in the appsettings.json file that can be found at cloud-restaurant-api\CloudRestaurant.API\appsettings.json inside the repository
2. (Optional) Update the URL where you want the API to be deployed in cloud-restaurant-api\CloudRestaurant.API\appsettings.json
3. Update the value for the 'apiRootUrl' field in cloud-restaurant-web-client\src\environments\environments.ts file in the repository, with the URL for the REST API. Remember to add '/api' to the end of the REST API Url.
4. Run ``` dotnet run ``` from inside the web api folder - /cloud-restaurant-api/CloudRestaurant.API - to launch the REST API. Alternatively you can use Visual studio to launch the REST API
5. To launch the angular app, from inside the angular project - /cloud-restaurant-web-client - first run ``` npm install ``` and then run ``` npm run ng serve ``` 



Note: By default, the app will not have any menu's configured. You can find a sample JSON to create a menu in the root of the repository with the name sample-menu.json. You can send this JSON, as is, to the Create Menu endpoint to create a menu