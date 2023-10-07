using AscNet.Common.Util;
using AscNet.SDKServer.Models;
using Newtonsoft.Json;

namespace AscNet.SDKServer.Controllers
{
    internal class ConfigController : IRegisterable
    {
        private static readonly Dictionary<string, ServerVersionConfig> versions = new();

        static ConfigController()
        {
            versions = JsonConvert.DeserializeObject<Dictionary<string, ServerVersionConfig>>(File.ReadAllText("./Configs/version_config.json"))!;
        }

        public static void Register(WebApplication app)
        {
            app.MapGet("/prod/client/config/com.kurogame.punishing.grayraven.en.pc/{version}/standalone/config.tab", (HttpContext ctx) =>
            {
                List<RemoteConfig> remoteConfigs = new();
                ServerVersionConfig versionConfig = versions.GetValueOrDefault((string)ctx.Request.RouteValues["version"]!) ?? versions.First().Value;

                foreach (var property in typeof(ServerVersionConfig).GetProperties())
                    remoteConfigs.AddConfig(property.Name, (string)property.GetValue(versionConfig)!);

                remoteConfigs.AddConfig("ApplicationVersion", (string)ctx.Request.RouteValues["version"]!);
                remoteConfigs.AddConfig("Debug", true);
                remoteConfigs.AddConfig("External", true);
                remoteConfigs.AddConfig("Channel", 1);
                remoteConfigs.AddConfig("PayCallbackUrl", "empty");
                remoteConfigs.AddConfig("PrimaryCdns", "http://prod-encdn-akamai.kurogame.net/prod|http://prod-encdn-aliyun.kurogame.net/prod");
                remoteConfigs.AddConfig("SecondaryCdns", "http://prod-encdn-aliyun.kurogame.net/prod");
                remoteConfigs.AddConfig("CdnInvalidTime", 600);
                remoteConfigs.AddConfig("MtpEnabled", false);
                remoteConfigs.AddConfig("MemoryLimit", 2048);
                remoteConfigs.AddConfig("CloseMsgEncrypt", false);
                remoteConfigs.AddConfig("ServerListStr", $"{Common.Common.config.GameServer.RegionName}#{Common.Common.config.GameServer.Host}/api/Login/Login");
                remoteConfigs.AddConfig("AndroidPayCallbackUrl", $"{Common.Common.config.GameServer.Host}/api/XPay/HeroHgAndroidPayResult"); // i just wanna know what this is
                remoteConfigs.AddConfig("IosPayCallbackUrl", $"{Common.Common.config.GameServer.Host}/api/XPay/HeroHgIosPayResult"); // i just wanna know what this is
                remoteConfigs.AddConfig("WatermarkEnabled", true); // i just wanna know what this is
                remoteConfigs.AddConfig("PicComposition", "empty"); // i just wanna know what this is
                remoteConfigs.AddConfig("DeepLinkEnabled", true);
                remoteConfigs.AddConfig("DownloadMethod", 1);
                remoteConfigs.AddConfig("PcPayCallbackList", $"{Common.Common.config.GameServer.Host}/api/XPay/KuroPayResult");

                return TsvTool.SerializeObject(remoteConfigs);
            });

            app.MapPost("/feedback", (HttpContext ctx) =>
            {
                return ctx.Response.WriteAsJsonAsync(new
                {
                    code = 0,
                    msg = "ok"
                });
            });
        }
    }
}
