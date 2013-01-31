using System;
using Ducksboard.Objects;
using Xunit;
using FluentAssertions;

namespace Ducksboard.Tests
{
    public class DashboardTests
    {
        private readonly DashboardClient _dashboardClient;
  
        public DashboardTests()
        {
            _dashboardClient = new DashboardClient("[YOUR API KEY]");
        }

        [Fact]
        public void Can_get_dashboards()
        {
            var dashboards =  _dashboardClient.GetAll<Dashboard>();
            dashboards.Should().NotBeEmpty();
        }

        [Fact]
        public void Can_get_widgets()
        {
            var widgets = _dashboardClient.GetAll<Widget>();
            widgets.Should().NotBeEmpty();
        }

        [Fact]
        public void Delete_unknown_dashboard_returns_0()
        {
            var deleted = _dashboardClient.Delete<Dashboard>("never made one called this");
            deleted.Should().BeFalse();
        }

        [Fact]
        public void Can_create_read_update_delete_dashboard()
        {
            var dashboardName =  Guid.NewGuid().ToString();
            var dashboard = new Dashboard()
            {
                Name = dashboardName,
                Background = "dark wood",
            };

            dashboard = _dashboardClient.Create(dashboard);
            dashboard.Should().NotBeNull();
           
            dashboard = _dashboardClient.Get<Dashboard>(dashboard.Slug);
            dashboard.Should().NotBeNull();

            var newDashboardName =  Guid.NewGuid().ToString();
            dashboard.Name = newDashboardName;

            dashboard = _dashboardClient.Update(dashboard, dashboard.Slug);
            dashboard.Name.ShouldBeEquivalentTo(newDashboardName);

            var deleted = _dashboardClient.Delete<Dashboard>(dashboard.Slug);
            deleted.Should().BeTrue();
        }

        [Fact]
        public void Can_create_read_update_delete_widget()
        {
            var dashboardName = Guid.NewGuid().ToString();
            var dashboard = new Dashboard()
            {
                Name = dashboardName,
                Background = "dark wood",
            };

            dashboard = _dashboardClient.Create(dashboard);
            dashboard.Should().NotBeNull();

            var widget = new Widget
            {
                WidgetProperties = new WidgetProperties
                    {
                        Kind = "custom_numeric_gauge",
                        Title = "TEST",
                        Dashboard = dashboard.Slug,
                        Width = 1,
                        Height = 1,
                        Row = 1,
                        Column = 1,
                        Sound = true

                    },
                Slots = new Slot
                    {
                        Slot1 = new SlotData
                            {
                                Subtitle = "watchers",
                                Timespan = "monthly",
                                Color = "#C11F70"
                            }
                    }
            };

            widget = _dashboardClient.Create(widget);
            widget.Should().NotBeNull();

            widget.WidgetProperties.Title = "TEST 1, 2";

            widget = _dashboardClient.Update(widget, widget.Slug);
            widget.WidgetProperties.Title.Should().Be("TEST 1, 2");

            var widgetDeleted = _dashboardClient.Delete<Widget>(widget.Slug);
            widgetDeleted.Should().BeTrue();

            var deleted = _dashboardClient.Delete<Dashboard>(dashboard.Slug);
            deleted.Should().BeTrue();
        }
    }
}
