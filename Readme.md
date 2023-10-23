# Panda.NuGet.BillbeeClient

Panda.NuGet.BillbeeClient is a .NET Core library designed to provide an easy-to-use interface for communicating with the Billbee API. This project is a fork of the [billbeeio/billbee-csharp-sdk](https://github.com/billbeeio/billbee-csharp-sdk) repository.

## Installation

The Panda.NuGet.BillbeeClient library is available as a NuGet package. You can install it via the NuGet package manager from the GitHub repository [pandapknaepel/billbee-csharp-sdk](https://github.com/pandapknaepel/billbee-csharp-sdk).

```bash
dotnet add package Panda.NuGet.BillbeeClient --version <version>
```

Replace `<version>` with the latest version number.

## Usage

To use the Panda.NuGet.BillbeeClient in your project, first, you need to configure the services in the `Startup.cs` file of your project.

```csharp
using Panda.NuGet.BillbeeClient.Extensions;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddBillbeeApi(new BillbeeApiConfig
        {
            Username = "your-username",
            Password = "your-password",
            ApiKey = "your-api-key",
            BaseUrl = "https://api.billbee.io"
        });
    }
}
```

You can now inject the `IBillbeeClient` interface wherever you need to use the Billbee API.

```csharp
public class MyService
{
    private readonly IBillbeeClient _billbeeClient;

    public MyService(IBillbeeClient billbeeClient)
    {
        _billbeeClient = billbeeClient;
    }

    public async Task DoSomethingAsync()
    {
        var events = await _billbeeClient.Events.GetEventsAsync();
        // ...
    }
}
```

## Features

Panda.NuGet.BillbeeClient supports various endpoints allowing access to different sections of the Billbee API, such as events, shipments, webhooks, products, automatic user creation, customer base data, customer addresses, orders, cloud storages, and enum values.

## Documentation

For more details on the Billbee API and what you can do with it, please refer to the [official Billbee API documentation](https://app.billbee.io/swagger/ui/index) or [Billbee's website](https://www.billbee.de/api/).

## Contributing

If you find any issues or have suggestions for improvements, feel free to open an issue or create a pull request. Your contributions are welcome!

## License

This project inherits the license from the original [billbeeio/billbee-csharp-sdk](https://github.com/billbeeio/billbee-csharp-sdk) repository.