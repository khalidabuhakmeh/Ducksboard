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

### Dashboard API

CRUD operations for Dashboards and widgets have been implemented in the dashboard api.

Example usage : 
```csharp
var dashboardClient = new DashboardClient("** Your API Key Here **");
var dashboard = new Dashboard()
            {
                Name = dashboardName,
                Background = "dark wood",
            };

dashboard = dashboardClient.Create(dashboard);

var leaderboard = client.Create(new Widget()
			{
			    WidgetProperties = new WidgetProperties()
			    {
			        Dashboard = dashboard.Slug,
			        Kind = "custom_textual_status_leaderboard",
			        Sound = true,
			        Title = "My Leaderboard",
			        Width = 1,
			        Height = 2
			    },
			    Slots = new Slot
			    {
			        Slot1 = new SlotData
			            {
			                Subtitle1 = "Thing",
			                Color1 = Color.DarkSlateBlue.ToDucksboardColor(),
			                Subtitle2 = "Status",
			                Color2 = Color.Black.ToDucksboardColor()
			            }
			    }
			});


leaderboard.Slots.Slot1.Label = "MySlotLabel";

dashboardCient.Update(leaderboard, leaderboard.Slug);



```
### Supported Objects

- Dashboards
- Widgets

NOTE: Currently widget content is not supported.  Any of the http://dev.ducksboard.com/apidoc/widgets-list/#custom-widgets Custom widgets can be used.

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

- Khalid Abuhakmeh ([@aquabirdconsult](http://twitter.com/aquabirdconsult))
- Brendan Tompkins ([@btompkins](http://twitter.com/btompkins))

## Pull Requests

Feel free to fork this project and send me a pull request, if you can create a unit test that would be great as well.
