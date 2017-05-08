![Build status](https://ci.appveyor.com/api/projects/status/github/simon-k/NancyByExample?svg=true&retina=true)

# NancyByExample
A short demonstration of how [NancyFX](http://nancyfx.org/) can be used to create a simple REST API, and how it is tested.

## Why I Like Nancy
- Easy to use (just start the host and add a module with routes)
- Easy to understand the routes. No magic compared to Web API or WCF
- Microservice ready: Lightweight, self-contained and easy to deplay as a service
- Testable
- IOC support (Autofac among others)

## How Nancy works
It's really simple. Create an instance of host with the given url and port where the endpoints should be located, and then start it.
Endpoints are defined in classes extending NancyModule.
Use IOC by creating a class extending XXXXX

TODO: ADD CODE EXAMPLES

## About This Solution
Just clone it and build it. Tests proves that it works.

### Dependencies
This project is dependent on the following nuget packages.
####Nancy.Hosting.Self
One of the really cool things Nancy can do is a self contained host. No need for an IIS or other framework.

#### Nancy.Bootstrappers.Autofac
To use the IOC pattern this package is included. It require Autofac.

### Projects in the solution
#### NancyByExample.API
The REST API based on NancyFX

#### NancyByExample.API.Domain
The domain objects. For simplicity this is a User which have a name, age and an address. The address is a street name, number, postcode and city.

#### NancyByExample.API.Repository
A simple repository for storing users. To keep it simple it's just a List. It is bacically just there for demonstrating Autofac IOC Container functionality.

## Notes
To run an api as a windows service I would reccommend using Topshelf (http://topshelf-project.com/).
