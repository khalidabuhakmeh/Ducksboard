using Ducksboard.Objects;
using FluentAssertions;
using Xunit;

namespace Ducksboard.Tests.Objects
{
    public class NumbersTests : SerializationTest
    {
        [Fact]
        public void Can_serialize_value_properly()
        {
            var target = new Numbers {Value = 3.5m};
            string result = Serializer.Serialize(target);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Can_call_to_json_on_a_ducksboard_object()
        {
            new Numbers {Value = 3}.ToJson().Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Can_serialize_delta_properly()
        {
            var target = new Numbers {Delta = 3.5m};
            string result = Serializer.Serialize(target);
            result.Should().NotBeNullOrEmpty();
        }
    }

    public class GaugesTests : SerializationTest
    {
        [Fact]
        public void Can_serialize_a_gague_properly()
        {
            var target = new Gauges {Value = 0.25m};
            string result = Serializer.Serialize(target);
            result.Should().NotBeNullOrEmpty();
        }
    }

    public class TimelineTests : SerializationTest
    {
        [Fact]
        public void Can_serialize_timeline_objects_properly()
        {
            var target = new Timeline();
            target.Value.Title = "error message";
            target.Value.Image = "http://assets.example.or/error.png";
            target.Value.Content = "All system stop!";
            target.Value.Link = "http://monitoring.example.org/incident/354";

            string result = Serializer.Serialize(target);
            result.Should().NotBeNullOrEmpty();
        }
    }

    public class ImageTests : SerializationTest
    {
        [Fact]
        public void Can_serialize_image_objects()
        {
            var target = new Image();
            target.Value.Source = "http://assets.example.org/logo.png";
            target.Value.Caption = "Example Corp, Inc.";

            string result = Serializer.Serialize(target);
            result.Should().NotBeNullOrEmpty();
        }
    }

    public class TextTests : SerializationTest
    {
        [Fact]
        public void Can_serialize_text_objects()
        {
            var target = new Text();
            target.Value.Content = @"Text!\nLorem ipsum dolor sit amet...";

            string result = Serializer.Serialize(target);
            result.Should().NotBeNullOrEmpty();
        }
    }

    public class LeaderboardTests : SerializationTest
    {
        [Fact]
        public void Can_serialize_leaderboard_objects()
        {
            var target = new Leaderboard();

            target
                .Add("Abdul-Jabbar", 38387, 1560, 24.6m)
                .Add("Karl Malone", 36928, 1476, 25.0m)
                .Add("Michael Jordan", 32292, 1072, 30.1m)
                .Add("W. Chamberlain", 31419, 1045, 30.1m)
                .Add("Kobe Bryant", 29484, 1161, 25.4m)
                .Add("Shaq O Neal", 28596, 1207, 23.7m)
                .Add("Moses Malone", 27409, 1329, 20.6m)
                .Add("Elvis Hayes", 28313, 1303, 21.0m)
                .Add("H. Olajuwon", 26946, 1238, 21.8m);

            string result = Serializer.Serialize(target);
            result.Should().NotBeNullOrEmpty();
        }
    }

    public class TrendLeaderboardTests : SerializationTest
    {
        [Fact]
        public void Can_serialize_trend_leaderboard_objects()
        {
            var target = new TrendLeaderboard();

            target
                .Add("value1", null, 1560, 24.6m)
                .Add("value2", null, 1560, 24.6m)
                .Add("value3", null, 1560, 24.6m)
                .Add("overridden", TrendLeaderboard.Trends.Up, 1560, 24.6m);


            string result = Serializer.Serialize(target);
            result.Should().NotBeNullOrEmpty();
        }
    }

    public class StatusLeaderboardTests : SerializationTest
    {
        [Fact]
        public void Can_serialize_status_leaderboard_objects()
        {
            var target = new StatusLeaderboard();

            target
                .Add("everything fine", StatusLeaderboard.Status.Green, "100%")
                .Add("warning, warning", StatusLeaderboard.Status.Yellow, "80%")
                .Add("very bad", StatusLeaderboard.Status.Red, "15%")
                .Add("not sure", StatusLeaderboard.Status.Gray, "--");

            string result = Serializer.Serialize(target);
            result.Should().NotBeNullOrEmpty();
        }
    }

    public class FunnelTests : SerializationTest
    {
        [Fact]
        public void Can_serialize_funnel_objects()
        {
            var target = new Funnel();

            target
                .Add("STEP 1", 1600)
                .Add("STEP 2", 1400)
                .Add("STEP 3", 1200)
                .Add("STEP 4", 900)
                .Add("STEP 5", 600)
                .Add("STEP 6", 330);

            string result = Serializer.Serialize(target);
            result.Should().NotBeNullOrEmpty();
        }
    }
}