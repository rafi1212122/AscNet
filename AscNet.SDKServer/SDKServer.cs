using AscNet.Logging;

namespace AscNet.SDKServer
{
    public class SDKServer
    {
        public static readonly Logger log = new(typeof(SDKServer), Logging.LogLevel.DEBUG, Logging.LogLevel.DEBUG);

        public static void Main(string[] args)
        {
            log.LogLevelColor[Logging.LogLevel.INFO] = ConsoleColor.Blue;
            var builder = WebApplication.CreateBuilder(args);

            // Disables default logger
            builder.Logging.ClearProviders();

            var app = builder.Build();

            app.Urls.Add("http://*:80");
            app.Urls.Add("https://*:443");

            IEnumerable<Type> controllers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IRegisterable).IsAssignableFrom(p) && !p.IsInterface)
                .Select(x => x);

            foreach (Type controller in controllers)
            {
                controller.GetMethod(nameof(IRegisterable.Register))!.Invoke(null, new object[] { app });
#if DEBUG
                log.Info($"Registered HTTP controller '{controller.Name}'");
#endif
            }

            app.UseMiddleware<RequestLoggingMiddleware>();

            new Thread(() => app.Run()).Start();
            log.Info($"{nameof(SDKServer)} started in port {string.Join(", ", app.Urls.Select(x => x.Split(':').Last()))}!");
        }

        private class RequestLoggingMiddleware
        {
            private readonly RequestDelegate _next;
            private static readonly string[] SurpressedRoutes = new string[] { "/feedback" };

            public RequestLoggingMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                finally
                {
                     log.Info($"{context.Response.StatusCode} {context.Request.Method.ToUpper()} {context.Request.Path + context.Request.QueryString}");
                }
            }
        }
    }

    public interface IRegisterable
    {
        public abstract static void Register(WebApplication app);
    }
}