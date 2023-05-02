# AutoICD .NET 7 ASP.NET Project

This is a .NET 7 ASP.NET project that demonstrates how to consume the [AutoICD API's](https:\\www.autoicdapi.com) clinical text coding endpoint. AutoICD is a RESTful API that provides automated [ICD-10](https://icd.who.int/browse10/2019/en) medical coding functionality.

## Getting Started

To get started with the project, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the solution to restore NuGet packages.
4. Start the project using IIS Express or another web server.
5. The project should open in your web browser at `http://localhost:<port>/`.

## Using the AutoICD API

The AutoICD API provides an endpoint `/api/code` for coding clinical text written in natural language to ICD-10 codes. 
To use the API, you will need an API key, which you can obtain by signing up on the AutoICD website.

Once you have an API key, add it to the `appsettings.json` file in the project root directory.

Once configured, run the application and you can interactively try the API by entering the clinical text to code, processing it and obtaining the JSON results coded in ICD-10.

For more information about using the AutoICD API, see the [AutoICD API documentation](https:\\www.autoicdapi.com).
## Contributing

If you would like to contribute to this project, feel free to open a pull request or submit an issue on the GitHub repository.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
