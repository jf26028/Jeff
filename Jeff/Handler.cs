﻿namespace Jeff
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Web;
    using System.Web.Routing;

    public abstract class Handler
    {
        #region constants 

        public const string Html = "text/html";

        public const string Json = "appliation/json";

        public const string Text = "text/plain";

        #endregion constants 

        #region private fields 

        private Dictionary<string, Dictionary<string, Func<string>>> routesAndResponses;

		#endregion private fields 

		#region constructors 

        public Handler()
        {
            this.routesAndResponses = new Dictionary<string, Dictionary<string, Func<string>>>();
        }

		#endregion constructors 

		#region properties 

        public string ContentType
        {
            get
            {
                return this.HttpContext.Response.ContentType;
            }
            set
            {
                this.HttpContext.Response.ContentType = value;
            }
        }

        public HttpContext HttpContext { get; set; }

        public IDictionary<string, string> Params 
        {
            get
            {
                IDictionary<string, string> paramsDictionary = new Dictionary<string, string>();

                NameValueCollection requestParams = this.HttpContext.Request.Params;
                foreach (var item in requestParams.AllKeys)
                {
                    paramsDictionary[item] = requestParams[item];
                }

                if (this.HttpContext.Items.Contains("routeData"))
                {
                    RouteData routeData = (RouteData)this.HttpContext.Items["routeData"];
                    foreach (var value in routeData.Values)
                    {
                        paramsDictionary[value.Key] = value.Value.ToString();
                    }
                }

                return paramsDictionary;
            }
        }

        public Dictionary<string, Dictionary<string, Func<string>>> RoutesAndResponses
        {
            get
            {
                return this.routesAndResponses;
            }
        }

		#endregion properties 

		#region public methods 

        public void AddRouteAndResponse(string method, string route, Func<string> response)
        {
            Dictionary<string, Func<string>> routeAndResponses;
            if (routesAndResponses.ContainsKey(route))
            {
                routeAndResponses = this.routesAndResponses[route];

                if (routeAndResponses.ContainsKey(method))
                {
                    routeAndResponses[method] = response;
                }
                else
                {
                    routeAndResponses.Add(method, response);
                }
            }
            else
            {
                Dictionary<string, Func<string>> methodAndFunction = new Dictionary<string, Func<string>>();
                methodAndFunction.Add(method, response);
                this.routesAndResponses.Add(route, methodAndFunction);
            }
        }

        public void Delete(string route, Func<string> response)
        {
            this.AddRouteAndResponse("DELETE", route, response);
        }

        public void Get(string route, Func<string> response)
        {
            this.AddRouteAndResponse("GET", route, response);
        }

        public void Post(string route, Func<string> response)
        {
            this.AddRouteAndResponse("POST", route, response);
        }

        public void Put(string route, Func<string> response)
        {
            this.AddRouteAndResponse("PUT", route, response);
        }
        
        public abstract void Routes();

		#endregion public methods 
    }
}