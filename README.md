# AnimeFlix



## How to use:
- You will need the latest Visual Studio 2022, dotnet-ef, and .NET Core SDK 6.0.
- ***Please check if you have installed the same runtime version (SDK) described in global.json***
- The latest SDK and tools can be downloaded from https://dot.net/core.
- to install dotnet-ef you can run in powershell this command: dotnet tool install --global dotnet-ef

## Commands to run to build database

- Open your terminal in the "\src\AnimeFlix.Infra.Data" folder
- Run this command in terminal : dotnet ef database update --startup-project ..\AnimeFlix.WebApi

## Let's run
- Open your terminal in the "\src\AnimeFlix.WebApi\AnimeFlix.WebApi" folder
- Run this command in terminal : dotnet run
