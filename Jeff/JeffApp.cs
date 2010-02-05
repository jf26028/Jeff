namespace Jeff
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Routing;

    public static class JeffApp
    {
		#region public static methods 

        public static void Initialise()
        {
            var classes = Assembly.GetCallingAssembly().GetTypes().Where(t => t.BaseType == typeof(Handler));
            foreach (var c in classes)
            {
                Handler handler = (Handler)Activator.CreateInstance(c);
                handler.Routes();

                foreach (var route in handler.RoutesAndResponses)
                {
                    RouteTable.Routes.Add(new Route(route.Key, new RouteHandler(route.Value, handler)));
                }
            }
        }

		#endregion public static methods 
    }
}