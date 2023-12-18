# Project Name

Short description of your web API project.

## Table of Contents

- [Project Overview](#project-overview)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [API Documentation](#api-documentation)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgments](#acknowledgments)

## Project Overview

This project is a work sample as a part of recruitment process at ----

## Getting Started
Open the ContactInformation.sln solution in Visual Studio. There should be two projects loading - 1) ContactInformation.Api and 2) ContactInformation.UnitTests

### Prerequisites

The web-api requires MongoDB for data storage and docker for packaging for deployment

### Installation

Before the application can be run, MongoDB connection string, database and collection has to be configured in the "ContactInfoDatabase" section of the appsettings.json file in ContactInformation.Api project.
To run the project locally in the debugger: open the ContactInformation.sln in VisualStudio, then right click the ContactInformation.Api project and select "Debug -> Start new instance" 

Docker:
The intention is to package and run this project in container using docker. There is a DockerFile in the project from which I was able to build an image but since I am a novice on docker I havent managed to get it to run yet. So there is a little bit of work to be done here still.

## API Documentation

There is a swagger available for the Api. When run in debugger the Api is typically found  at https://localhost:7111/swagger/index.html 

## Testing

There is a unit test project in the solution. Its setup for writing unit tests using Xunit, Moq and FluentAssertions


## Acknowledgments

Acknowledgements to ---- giving me this interesting challenge 
