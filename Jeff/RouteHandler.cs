namespace Jeff
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Routing;

    public class RouteHandler : IRouteHandler
    {
        private Handler handler;

        private Dictionary<string, Func<string>> methodsAndResponses;

        public RouteHandler(Dictionary<string, Func<string>> methodsAndResponses, Handler handler)
        {
            this.methodsAndResponses = methodsAndResponses;
            this.handler = handler;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.HttpContext.Items.Add("routeData", requestContext.RouteData);
            return new HttpHandler(this.methodsAndResponses, this.handler);
        }
    }
}
