using AscNet.Common.Util;
using AscNet.SDKServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                remoteConfigs.AddConfig("AndroidPayCallbackUrl", $"{Common.Common.config.GameServer.Host}/api/XPay/HeroHgAndroidPayResult");
                remoteConfigs.AddConfig("IosPayCallbackUrl", $"{Common.Common.config.GameServer.Host}/api/XPay/HeroHgIosPayResult");
                remoteConfigs.AddConfig("WatermarkEnabled", false); // i just wanna know what this is
                remoteConfigs.AddConfig("PicComposition", "empty");
                remoteConfigs.AddConfig("DeepLinkEnabled", true);
                remoteConfigs.AddConfig("DownloadMethod", 1);
                remoteConfigs.AddConfig("PcPayCallbackList", $"{Common.Common.config.GameServer.Host}/api/XPay/KuroPayResult");

                return TsvTool.SerializeObject(remoteConfigs);
            });

            app.MapGet("/prod/client/notice/config/com.kurogame.punishing.grayraven.en.pc/{version}/LoginNotice.json", (HttpContext ctx) =>
            {
                return JsonConvert.SerializeObject(new LoginNotice()
                {
                    BeginTime = 0,
                    EndTime = 0,
                    HtmlUrl = "/",
                    Id = "1",
                    ModifyTime = 0,
                    Title = "NOTICE"
                });
            });

            app.MapPost("/feedback", (HttpContext ctx) =>
            {
                return "1";
            });

            app.MapGet("/api/Login/Login", ([FromQuery] int loginType, [FromQuery] int userId, [FromQuery] string token, [FromQuery] string clientIp) =>
            {
                return JsonConvert.SerializeObject(new LoginGate()
                {
                    Code = 0,
                    Ip = Common.Common.config.GameServer.Host,
                    Port = Common.Common.config.GameServer.Port,
                    Token = token
                });
            });
        }
    }
}
