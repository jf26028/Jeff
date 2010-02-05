namespace Example
{
    using System;
    using System.Web;
    using Jeff;

    public class Global : HttpApplication
    {
		#region protected methods 

        protected void Application_Start(object sender, EventArgs e)
        {
            JeffApp.Initialise();
        }

		#endregion protected methods 
    }
}