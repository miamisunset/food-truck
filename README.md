# FoodTruck

- [ Description ](#description)
- [ Local Requirements ](#local-requirements)
- [ Docker Deployment ](#docker-deployment)
- [ Running Tests Locally ](#running-tests-locally)

## Description

An example project written using .NET. It is designed using Clean Architecture, Mediator (CQRS in other words) and Result 
patterns. The project also uses feature based organization principle.

## Local Requirements

- Linux, MacOS or... Windows 
- .NET 8.0
- dotnet tool installed

To run locally just clone repository to whatever location, change to the solution root and execute `dotnet run`

## Docker Deployment

1. Ensure Docker or Docker Desktop is installed.
2. Clone repository
3. Change to wherever repository was cloned
4. Run `docker-compose up`

The application exposes default production port 8080 on http i.e. `http://localhost:8080/`

Swagger is enabled by default in production to make things easier and is accessible at `http://localhost:8080/swagger`

## Running Tests Locally

To run all tests just execute `dotnet test` from the solution root.
