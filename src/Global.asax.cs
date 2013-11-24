using System;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.WebHost.Endpoints;

namespace SimpleMarkdownExample
{
    public class Global : System.Web.HttpApplication
    {
        public class AppHost : AppHostBase
        {
            public AppHost() : base("Simple Razor Markdown example", typeof(CatchAllService).Assembly) { }

            public override void Configure(Funq.Container container) {}
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }
    }

    [ClientCanSwapTemplates]
    [FallbackRoute("/{Path*}")]
    public class CatchAll
    {
        public string Path { get; set; }
    }

    public class CatchAllResponse
    {
        public string Path { get; set; }
        public string TestProp { get; set; }
    }

    public class CatchAllService : Service
    {
        public object Any(CatchAll req)
        {
            var response = new CatchAllResponse
            {
                Path = req.Path,
                TestProp = "Rob woz here!"
            };
            return response;
        }
    }
}