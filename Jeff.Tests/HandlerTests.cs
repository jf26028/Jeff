namespace Jeff.Tests
{
    using Xunit;

    public class HandlerTests
    {
        [Fact]
        public void TestAddingRoutes()
        {
            SimpleHandler handler = new SimpleHandler();
            handler.Routes();

            var routesAndResponses = handler.RoutesAndResponses;
            Assert.Equal(1, routesAndResponses.Count);
            Assert.Equal(4, routesAndResponses["one"].Count);

            Assert.True(routesAndResponses["one"].ContainsKey("GET"));
            Assert.True(routesAndResponses["one"].ContainsKey("PUT"));
            Assert.True(routesAndResponses["one"].ContainsKey("POST"));
            Assert.True(routesAndResponses["one"].ContainsKey("DELETE"));
        }

        [Fact]
        public void TestOverwriteARoute()
        {
            SameRouteHandler handler = new SameRouteHandler();
            handler.Routes();

            var routesAndResponses = handler.RoutesAndResponses;
            Assert.Equal(1, routesAndResponses.Count);
            Assert.Equal(1, routesAndResponses["one"].Count);
            Assert.Equal("One Overwritten", routesAndResponses["one"]["GET"].Invoke());
        }

        [Fact]
        public void CreateMultipleRoutes()
        {
            MultipleRoutesHandler handler = new MultipleRoutesHandler();
            handler.Routes();

            var routesAndResponses = handler.RoutesAndResponses;
            Assert.Equal(2, routesAndResponses.Count);
            Assert.Equal(1, routesAndResponses["one"].Count);
            Assert.Equal(1, routesAndResponses["two"].Count);
        }
    }

    public class SimpleHandler : Handler
    {
        public override void Routes()
        {
            Get("one", () => "One");
            Put("one", () => "One");
            Post("one", () => "One");
            Delete("one", () => "One");
        }
    }

    public class SameRouteHandler : Handler
    {
        public override void Routes()
        {
            Get("one", () => "One");
            Get("one", () => "One Overwritten");
        }
    }

    public class MultipleRoutesHandler : Handler
    {
        public override void Routes()
        {
            Get("one", () => "One");
            Get("two", () => "Two");
        }
    }
}