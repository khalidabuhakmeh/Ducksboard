using Ducksboard.Objects;
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
            Dashboard.Update("** Widget **", new Numbers {Value = 0});
        }

        [Fact]
        public void Can_update_an_image_widget()
        {
            Dashboard.Update("** Widget **",
                             new Image("http://i.telegraph.co.uk/multimedia/archive/01452/fer1_1452403i.jpg", "Ferrari"));
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

            Dashboard.Update("** Widget **", timeline);
        }
    }
}