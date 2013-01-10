Ducksboard API for .NET
======================================

This project contains objects specifically tied to the Ducksboard API, giving you the ability to update your Ducksboard dashboard from your .NET applications.
The objects contained here can be used for both Push and Pull APIs. You can sign up for Ducksboard at http://www.ducksboard.com.

*** This project has a dependency on RestSharp ***

## Gettings Started

Through Nuget (http://nuget.org):

```csharp
PM > Install-Package Ducksboard
```
Somewhere in your code (Push API):

```csharp
var dashboard = new DucksboardClient("** Your API Key Here **");
var response = dashboard.Update("**widget number**", new Numbers { Value = 3.5 });
```

Note: the response object will let you know if it was successful in updating. It is not worth looking at unless you are running into issues. I exposed it so you can debug issues more easily.

### Supported Objects

- Funnel
- Gauges
- Image
- Leaderboard
- Numbers
- StatusLeaderboard
- Text
- Timeline (my personal favorite)
- TrendLeaderboard


## ASP.NET and Pull API

Using the pull API is very simple, you just need to provide Ducksboard with a url to pull from and provide the same JSON you would push to them. Below is a quick example with ASP.NET MVC.

```csharp
  // imagine this is in your publicly accessible controller
  public ActionResult Tickets() {
    var numOfTickets = db.Tickets.Count();
    return Content(new Numbers { Value = numOfTickets }.ToJson());  
  }
```

**ToJson()** is a member method of all Ducksboard objects, so you can use it anywhere you can host a web process.


## Contributors

Written by Khalid Abuhakmeh

## Pull Requests

Feel free to fork this project and send me a pull request, if you can create a unit test that would be great as well.
