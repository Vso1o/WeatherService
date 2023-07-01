Project Overview:

This solution consists of three projects, each representing different layers of the application. The main purpose of this application is to interact with an external API and provide data through various endpoints.

Project Structure:

The solution contains the following projects:

Data Layer: This project named "WeatherService.Core" contains DTOs and Converter for them.
Business Layer: This project named "WeatherService.Business" implements the business logic of project.
API Layer: This project named "WeatherService.Api" provides the API endpoints for clients to consume. It takes care of exceptions with designated middleware.

Configuration:

The application relies on the appsettings.json file to store the API key and base URI. These values are loaded from the configuration file during runtime.

Usage:

To run the application, ensure that you have properly configured the API key and base URI in the appsettings.json file.
Note that any "unexpected" exceptions always return response with status code 500.
