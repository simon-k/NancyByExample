![Build status](https://ci.appveyor.com/api/projects/status/github/simon-k/NancyByExample?svg=true&retina=true)

# NancyByExample
A short demonstration of how [NancyFX](http://nancyfx.org/) can be used to create a simple REST API, and how it is tested.

## Why I Like Nancy
- Easy to use (just start the host and add a module with routes)
- Easy to understand the routes. No magic compared to Web API or WCF
- Microservice ready: Lightweight, self-contained and easy to deplay as a service
- Testable
- IOC support (Autofac among others)

Here are some quotes from the famous guys:

Scott Hanselman<br/>
_"Nancy is a very complete and sophisticated framework with a LOT of great code to explore. It's extremely modular and flexible. It works with ASP.NET, with WCF, on Azure, with Owin, alongside Umbraco, with Mono, and so much more. I'm looking forward to exploring their .NET Core version as it continues development."_
[Link](https://www.hanselman.com/blog/ExploringAMinimalWebAPIWithNETCoreAndNancyFX.aspx)

Technology Radar by ThoughtWorks<br/>
_"Adobt! Since we last talked about Nancy on the technology radar it has become the default choice on our .NET projects. Architectures centred around small, vertical slices and microservices simply require light-weight deployment options and low ceremony tooling."_
[Link](https://www.thoughtworks.com/radar/languages-and-frameworks/nancy)

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

## TODO
- Make domain lib a model lib
- Include tests
- Include a client

## Notes
To run an api as a windows service I would reccommend using Topshelf (http://topshelf-project.com/).
