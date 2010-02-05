namespace Jeff
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public class HttpHandler : IHttpHandler
    {
        private Handler handler;

        private Dictionary<string, Func<string>> methodsAndResponses;

        public HttpHandler(Dictionary<string, Func<string>> methodsAndResponses, Handler handler)
        {
            this.methodsAndResponses = methodsAndResponses;
            this.handler = handler;
        }

        public bool IsReusable
        {
            get { return true; }
        }

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
    }
}
