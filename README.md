# sdk-dotnet-safedns

This is the official .NET SDK for UKFast SafeDNS

You should refer to the [Getting Started](https://developers.ukfast.io/getting-started) section of the API documentation before proceeding below

## Basic usage

To get started, we'll first instantiate an instance of `IUKFastSafeDNSClient`:

```csharp
IUKFastSafeDNSClient client = new UKFastSafeDNSClient(new ClientConnection("myapikey"));
```

Next, we'll obtain an instance of IZoneOperations to perform operations on DNS zones:

```csharp
var zoneOps = client.ZoneOperations();
```

Finally, we'll retrieve all zones using the instance of `IZoneOperations`:

```csharp
IList<Zone> zones = await zoneOps.GetZonesAsync();
```

## Operations

Several operations are available via `IUKFastSafeDNSClient`:

- `ZoneOperations()` - returns an instance of `IZoneOperations` for performing zone operations
- `ZoneRecordOperations()` - returns an instance of `IZoneRecordOperations` for performing zone record operations
- `ZoneNoteOperations()` - returns an instance of `IZoneNoteOperations` for performing zone note operations
- `TemplateOperations()` - returns an instance of `ITemplateOperations` for performing template operations
- `TemplateRecordOperations()` - returns an instance of `ITemplateRecordOperations` for performing template record operations
