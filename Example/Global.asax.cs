namespace Example
{
    using System;
    using System.Web;
    using Jeff;

    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            JeffApp.Initialise();
        }
    }
}
