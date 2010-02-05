namespace Jeff
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Routing;

    public class RouteHandler : IRouteHandler
    {
		#region private fields 

        private Handler handler;

        private Dictionary<string, Func<string>> methodsAndResponses;

		#endregion private fields 

		#region constructors 

        public RouteHandler(Dictionary<string, Func<string>> methodsAndResponses, Handler handler)
        {
            this.methodsAndResponses = methodsAndResponses;
            this.handler = handler;
        }

		#endregion constructors 

		#region public methods 

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.HttpContext.Items.Add("routeData", requestContext.RouteData);
            return new HttpHandler(this.methodsAndResponses, this.handler);
        }

		#endregion public methods 
    }
}