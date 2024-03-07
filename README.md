# AML Setup Library  [![NuGet](https://img.shields.io/nuget/v/AMLSetupLib)](https://www.nuget.org/packages/AMLSetupLib)

## Overview

AML Setup Library provides an easy way to interface with an AML device to configure its settings and get hardware info. 
The library allows you to create an instance of AMLSetupClient. 
You can configure the device settings with a AML Setup configuration json string.
This library works for Android.Xamarin, Xamarin Forms, and Maui.

## Usage

The library contains a class called `AMLSetupClient` that is used to interface with the device:

```csharp
var client = new AMLSetupClient(this);
```

The parameter for the constructor is the `Context` of the Android application.

## Example

```csharp
var client;
bool _connected = false;

public void InitAMLClient()
{
    client = new AMLSetupClient(this);
    scanner.Connected += AMLClientConnected; 
    scanner.Error += AMLClientError;
}

public void AMLClientConnected(bool permissionGranted)
{
    if (permissionGranted)
    {
        _connected = true;
        //Perform operations
    }
}

public void AMLClientError(SdkError error)
{
    //Handle error
}
```
