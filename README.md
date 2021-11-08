# Web API technical test 

This project demonstrates Clear Architecture REST api. Solution is made of three projects:
- Core: contains entites, interfaces, and domain services
- Infrastructure: containes everything needs for operation with external systems like databases
- WebApi: Application layer, hostable web api, contains data trasfer objects, enables mapping to domain objects, provides exceptions middleware, swagger UI. Solutions uses api endpoints instead of classic controller clases.

# External packages
- [Ardalis.GuardClauses](https://github.com/ardalis/GuardClauses) - A simple extensible package with guard clause extensions. 
- [Ardalis.ApiEndpoints](https://github.com/ardalis/ApiEndpoints) - A project for supporting API Endpoints in ASP.NET Core web applications.



## Running the sample
For this project, I am using Microsoft Visual Studio Enterprise 2019

After cloning or downloading the sample you should be able to run it using an SQLLite database immediately.

You can also run the WebAPi project in Docker.

### Task 1 
Write a RESTful API for creating, updating and retrieving customer information. A 
customer consists of the following fields: 
First name; 
Surname; 
E-mail address; 
Password. 
 
The API should satisfy the following requirements: 
 
1. The API should support create, update and retrieval operations for customer 
information via different routes; 
2. The customer data should be persisted in a database (you can choose which database 
engine); 
3. The API should be unit tested; 
4. The API should be well structured.

### Task 2 
This task involves building and running your application. 
 
1. Write a script that can be used to build your API and package it in a container; 
2. Create a docker-compose.yml file that will run your application as well as a valid 
database for it to use; 
3. Document how the API can be run locally, using Docker, along with some sample web 
requests. You might do this via a 
simple integration test, or via usage instructions. 
 
The final part of this task should illustrate your API running locally with its database and 
should be explicit enough for anyone else to follow the instructions and see the 
application working.

### Task 3
Finally, consider how the API could: 
1. Be deployed to a live environment; 
2. Handle a large volume of requests, including concurrent creation and update 
operations; 
3. Continue operating in the event of problems reading and writing from the database; 
4. Ensure the security of the user information. 

## Testing projects
The solution includes three testing projects. The projects are:
- UnitTest: contains functionality checks for the Customer entity and the domain model
- IntegrationTest: contains tests to check the functionality of database access through Repository and CustomersContext
- FunctionalTests: contains functionality checks for the API

## Running the sample using Docker

You can run the Web sample by running these commands from the root folder (where the .sln file is located):

```
docker-compose build
docker-compose up
```
You should be able to make requests to localhost:5106 for the Web project, and localhost:5200 for the Public API project once these commands complete. If you have any problems, especially with login, try from a new guest or incognito browser instance.

You can also run the applications by using the instructions located in their `Dockerfile` file in the root of each project. Again, run these commands from the root of the solution (where the .sln file is located).


