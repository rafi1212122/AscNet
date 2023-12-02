using AscNet.Common.Util;
using AscNet.SDKServer.Models;
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
            app.MapGet("/prod/client/config/{package}/{version}/standalone/config.tab", (HttpContext ctx) =>
            {
                List<RemoteConfig> remoteConfigs = new();
                ServerVersionConfig versionConfig = versions.GetValueOrDefault((string)ctx.Request.RouteValues["version"]!) ?? versions.First().Value;

                foreach (var property in typeof(ServerVersionConfig).GetProperties())
                    remoteConfigs.AddConfig(property.Name, (string)property.GetValue(versionConfig)!);

                remoteConfigs.AddConfig("ApplicationVersion", (string)ctx.Request.RouteValues["version"]!);
                remoteConfigs.AddConfig("Debug", true);
                remoteConfigs.AddConfig("External", true);
                remoteConfigs.AddConfig("PayCallbackUrl", "empty");
                switch ((string?)ctx.Request.RouteValues["package"])
                {
                    case "com.kurogame.haru.kuro":
                        remoteConfigs.AddConfig("PrimaryCdns", "http://prod-zspnsalicdn.kurogame.com/prod");
                        remoteConfigs.AddConfig("SecondaryCdns", "http://prod-zspnstxcdn.kurogame.com/prod");
                        remoteConfigs.AddConfig("Channel", 2);
                        break;
                    default:
                        remoteConfigs.AddConfig("PrimaryCdns", "http://prod-encdn-akamai.kurogame.net/prod|http://prod-encdn-aliyun.kurogame.net/prod");
                        remoteConfigs.AddConfig("SecondaryCdns", "http://prod-encdn-aliyun.kurogame.net/prod");
                        remoteConfigs.AddConfig("Channel", 1);
                        break;
                }
                remoteConfigs.AddConfig("CdnInvalidTime", 60);
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

                // 2.9.0
                remoteConfigs.AddConfig("WatermarkType", 2);
                remoteConfigs.AddConfig("ChannelServerListStr", $"1#{Common.Common.config.GameServer.RegionName}#{Common.Common.config.GameServer.Host}/api/Login/Login");

                string serializedObject = TsvTool.SerializeObject(remoteConfigs);
                SDKServer.log.Info(serializedObject);
                return serializedObject;
            });

            app.MapGet("/prod/client/notice/config/{package}/{version}/LoginNotice.json", (HttpContext ctx) =>
            {
                LoginNotice notice = new()
                {
                    BeginTime = 0,
                    EndTime = 0,
                    HtmlUrl = "/",
                    Id = "1",
                    ModifyTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    Title = "NOTICE"
                };

                string serializedObject = JsonConvert.SerializeObject(notice);
                SDKServer.log.Info(serializedObject);
                return serializedObject;
            });

            app.MapGet("/prod/client/notice/config/{package}/{version}/ScrollTextNotice.json", (HttpContext ctx) =>
            {
                ScrollTextNotice notice = new()
                {
                    Id = "1",
                    ModifyTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    BeginTime = 0,
                    EndTime = 0,
                    Content = "[ANNOUNCEMENT] There is no announcement.",
                    ScrollInterval = 300,
                    ScrollTimes = 15,
                    ShowInFight = 1,
                    ShowInPhotograph = 1
                };

                string serializedObject = JsonConvert.SerializeObject(notice);
                SDKServer.log.Info(serializedObject);
                return serializedObject;
            });

            app.MapGet("/prod/client/notice/config/{package}/{version}/ScrollPicNotice.json", (HttpContext ctx) =>
            {
                ScrollPicNotice notice = new()
                {
                    Id = "1",
                    ModifyTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    Content = new ScrollPicNotice.NoticeContent[]
                    {
                        new ScrollPicNotice.NoticeContent()
                        {
                            Id = 0,
                            PicAddr = "0",
                            JumpType = "0",
                            JumpAddr = "0",
                            PicType = "0",
                            Interval = 5,
                            BeginTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                            EndTime = DateTimeOffset.Now.ToUnixTimeSeconds() + 3600 * 24,
                            AppearanceCondition = Array.Empty<dynamic>(),
                            AppearanceDay = Array.Empty<dynamic>(),
                            AppearanceTime = Array.Empty<dynamic>(),
                            DisappearanceCondition = Array.Empty<dynamic>(),
                        }
                    }
                };

                string serializedObject = JsonConvert.SerializeObject(notice);
                SDKServer.log.Info(serializedObject);
                return serializedObject;
            });

            app.MapGet("/prod/client/notice/config/{package}/{version}/GameNotice.json", (HttpContext ctx) =>
            {
                List<GameNotice> notices = new();

                string serializedObject = JsonConvert.SerializeObject(notices);
                SDKServer.log.Info(serializedObject);
                return serializedObject;
            });

            app.MapPost("/feedback", (HttpContext ctx) =>
            {
                SDKServer.log.Info("1");
                return "1";
            });
        }
    }
}
