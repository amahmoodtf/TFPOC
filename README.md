# TFPOC

TFPOC is a proof-of-concept .NET Framework solution for integrating web applications with Apache Solr/SolrCloud.

## Solution structure

- `/home/runner/work/TFPOC/TFPOC/MySolrCore`  
  Shared library with Solr models, configuration helpers, and Solr connection/operation logic.
- `/home/runner/work/TFPOC/TFPOC/MYTFSolrWebApplicationClient`  
  ASP.NET Web Forms client application for MYTF scenarios.
- `/home/runner/work/TFPOC/TFPOC/PIMSolrWebApplicationClient`  
  ASP.NET Web Forms client application for PIM scenarios.
- `/home/runner/work/TFPOC/TFPOC/SolrWebApplicationClient.sln`  
  Visual Studio solution that contains all projects.

## Prerequisites

- Windows development environment
- Visual Studio (solution format targets VS 2022)
- .NET Framework 4.7.2 targeting pack
- ASP.NET Web Application build targets (WebApplication targets)
- Access to the required Solr/SolrCloud environment

> Note: Building with `dotnet build` on Linux fails for this repository because it depends on legacy .NET Framework + Visual Studio web application targets.

## Configuration

Solr connection settings are configured in:

- `/home/runner/work/TFPOC/TFPOC/MYTFSolrWebApplicationClient/Web.config`
- `/home/runner/work/TFPOC/TFPOC/PIMSolrWebApplicationClient/Web.config`

Update `appSettings` values such as:

- `SolrZooKeeperConnectionString`
- `SolrCloudModeEnabled`
- `SolrUserName`
- `SolrPassword`

Use environment-appropriate values and avoid committing real credentials.

## Build and run

1. Open `/home/runner/work/TFPOC/TFPOC/SolrWebApplicationClient.sln` in Visual Studio.
2. Restore NuGet packages.
3. Build the solution.
4. Run either web application project with IIS Express.
