namespace Jeff
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public class HttpHandler : IHttpHandler
    {
		#region private fields 

        private Handler handler;

        private Dictionary<string, Func<string>> methodsAndResponses;

		#endregion private fields 

		#region constructors 

        public HttpHandler(Dictionary<string, Func<string>> methodsAndResponses, Handler handler)
        {
            this.methodsAndResponses = methodsAndResponses;
            this.handler = handler;
        }

		#endregion constructors 

		#region properties 

        public bool IsReusable
        {
            get { return true; }
        }

		#endregion properties 

		#region public methods 

        public void ProcessRequest(HttpContext context)
        {
            if (this.methodsAndResponses.ContainsKey(context.Request.HttpMethod))
            {
                this.handler.HttpContext = context;
                string response = this.methodsAndResponses[context.Request.HttpMethod].Invoke();
                context.Response.Write(response);
            }
            else
            {
                context.Response.StatusCode = 404;
                context.Response.End();
            }
        }

		#endregion public methods 
    }
}