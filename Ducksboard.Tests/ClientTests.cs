using System.Net;
using Ducksboard.Objects;
using FluentAssertions;
using Xunit;

namespace Ducksboard.Tests
{
    public class ClientTests
    {
        public ClientTests()
        {
            Dashboard = new DucksboardClient("** Your API Key Here **");
        }

        private DucksboardClient Dashboard { get; set; }

        [Fact]
        public void Can_update_a_number_widget()
        {
            var response = Dashboard.Update("** Widget **", new Numbers { Value = 0 });
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public void Can_update_an_image_widget()
        {
            var response = Dashboard.Update("** Widget **", new Image("http://i.telegraph.co.uk/multimedia/archive/01452/fer1_1452403i.jpg", "Ferrari"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public void Can_update_a_timeline_widget()
        {
            var timeline = new Timeline();
            timeline.Value.Title = "Checkout this Ferrari 458";
            timeline.Value.Image = "http://i.telegraph.co.uk/multimedia/archive/01452/fer1_1452403i.jpg";
            timeline.Value.Content = "Vroooooooom!";
            timeline.Value.Link =
                "http://www.telegraph.co.uk/motoring/car-manufacturers/ferrari/5931105/Ferrari-458-photo-gallery.html";

            var response = Dashboard.Update("** Widget **", timeline);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public void Can_pass_in_many_numbers_to_a_graph()
        {
            var response = Dashboard.Updates("** Widget **", new[] { new Numbers { Value = 3 }, new Numbers { Value = 4 } });
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}