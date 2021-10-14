# Coding Challenge

## How to Run the project / Set up development environment

### API

1. Navigate to <https://github.com/rohanepa/codechallenge>
2. Clone the repository (git clone <https://github.com/rohanepa/codechallenge.git>)
3. Open the solution from Visual Studio
4. Make project “CarSales.CodingChallenge.Api” as the startup project
5. Add the rule endine to be able to run the code

Please note that you don’t need to do any additional step to setup the data store as the provided json has been copied in “Database” folder of “CarSales.CodingChallenge.Persistence” project and marked as “Copy Always” to copy it to working directory when running the project. If you are running out of sales people when testing, please restart the Api.

### Front End

1. Use visual studio code and open “Web” folder
2. Open a terminal
3. Run `npm install` to install dependacies
4. Complete the code and call the apis to be able to run.

Please note that latest node version has (12.x.x) has been used with Angular 10. Navigate to `http://localhost:4200/`.

## API Project Structure

Api is divided into multiple layers / projects;

`CarSales.CodingChallenge.Api` – A web api project, which receives requests from SPA.
`CarSales.CodingChallenge.Service` – The requests received to above project would be delegated to the relevant classes in this project. The responsibility of this project is to validate, process, perform the business logic and generate the response and pass back to web api project.
CarSales.CodingChallenge.Persistence – Purpose of this layer is to take care of any data related operations. For all CRUD operations, the service project will use this layer. MediatR (<https://github.com/jbogard/MediatR>) has been used to separate commands and queries.
`CarSales.CodingChallenge.Infrastructure` – This library is shared across all of above mentioned layers. This library contains all the DTOs, Enums, helper functions and building blocks of the framework if needed.
`CarSales.CodingChallenge.Tests` – Contains unit test cases.

A global error handler is done to catch any unexpected error from the api and log that. Serilog is used for logging. Please see GlobalExceptionHandlerMiddleware under config folder of the web api project. This is registered as a middleware in startup.

## Front End (SPA)

Front end is an Angular 10 project created using Angular CLI. The style guide in Angular documentation has been used to organise the project. The Customer – Sales Person assignment component resides in a separate module called Home.

Bootsrap library has been used to do the design and Angular Material library has been used for the controls. Reactive forms has been used for validations. Less has been used for styles. And test cases are done to cover the dashboard component under home module.

Run `ng test` or `npm test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Techstack

1. .Net Core
2. Web Api
3. Serilog
4. JsonFlatFileDataStore (<https://github.com/ttu/json-flatfile-datastore>) – To read and write to json data store.
5. MediatR (<https://github.com/jbogard/MediatR>) – For command and query segregation
6. FluentValidation – To validate requests
7. NSubstitue
8. Microsoft testing framework
9. Autofac
10. Angular 10
11. Typescript
12. Less
13. Angular Material
14. Bootstrap
15. Html
16. Jasmin
