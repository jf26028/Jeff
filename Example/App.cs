namespace Example
{
    using System;
    using Jeff;

    public class App : Handler
    {
        public override void Routes()
        {
            Get("/hello", () => "Hello!");
            Post("/hello", () => "Hello! POST, posted: " + Params["example"]);
            Put("/hello", () => "Hello! PUT");
            Delete("/hello", () => "Hello! DELETE");

            Get("/hello/{name}", () => string.Format("Hello {0}", Params["name"]));

            Get("/resource.{format}", () =>
            {
                switch (Params["format"])
                {
                    case "txt":
                        ContentType = Text;
                        return "A text file";
                    case "html":
                        ContentType = Html;
                        return "<b>A</b> html <i>file</i>";
                    case "json":
                        ContentType = Json;
                        return "{ \"name\" : \"value\" }";
                    case "xml":
                        ContentType = "application/xml";
                        return "<xml><name>Xml</name></xml>";
                }
                
                return "Don't know what to do with this"; 
            });

            Get("/agent", () => "Your using: " + HttpContext.Request.Headers["User-Agent"].ToString());

            Get("/callmethod", CallMethod);
        }

        private string CallMethod()
        {
            return "<!DOCTYPE html><html><head><title>Something</title></head><body><h1>Something</h1><p>A page with some stuff on</p></body></html>";
        }
    }
}
