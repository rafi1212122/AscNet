using System.Text;
using AscNet.Common.Database;
using AscNet.SDKServer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AscNet.SDKServer.Controllers
{
    public class AccountController : IRegisterable
    {
        public static void Register(WebApplication app)
        {
            app.MapPost("/api/AscNet/register", (HttpContext ctx) =>
            {
                AuthRequest? req = JsonConvert.DeserializeObject<AuthRequest>(Encoding.UTF8.GetString(ctx.Request.BodyReader.ReadAsync().Result.Buffer));

                if (req is null)
                {
                    return JsonConvert.SerializeObject(new
                    {
                        code = -1,
                        msg = "Invalid request"
                    });
                }

                try
                {
                    Account account = Account.Create(req.Username, req.Password);

                    return JsonConvert.SerializeObject(new
                    {
                        code = 0,
                        msg = "OK",
                        account
                    });
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(new
                    {
                        code = -1,
                        msg = ex.Message
                    });
                }
            });

            app.MapPost("/api/AscNet/login", (HttpContext ctx) =>
            {
                AuthRequest? req = JsonConvert.DeserializeObject<AuthRequest>(Encoding.UTF8.GetString(ctx.Request.BodyReader.ReadAsync().Result.Buffer));

                if (req is null)
                {
                    return JsonConvert.SerializeObject(new
                    {
                        code = -1,
                        msg = "Invalid request"
                    });
                }

                Account? account = Account.FromUsername(req.Username, req.Password);

                if (account == null)
                {
                    return JsonConvert.SerializeObject(new
                    {
                        code = -1,
                        msg = "Invalid credentials!"
                    });
                }

                return JsonConvert.SerializeObject(new
                {
                    code = 0,
                    msg = "OK",
                    account
                });
            });

            app.MapPost("/api/AscNet/verify", (HttpContext ctx) =>
            {
                AuthRequest? req = JsonConvert.DeserializeObject<AuthRequest>(Encoding.UTF8.GetString(ctx.Request.BodyReader.ReadAsync().Result.Buffer));

                if (req is null || req.Token == string.Empty)
                {
                    return JsonConvert.SerializeObject(new
                    {
                        code = -1,
                        msg = "Invalid request"
                    });
                }

                Account? account = Account.FromToken(req.Token);

                if (account == null)
                {
                    return JsonConvert.SerializeObject(new
                    {
                        code = -1,
                        msg = "Invalid credentials!"
                    });
                }

                return JsonConvert.SerializeObject(new
                {
                    code = 0,
                    msg = "OK",
                    account
                });
            });

            app.MapGet("/api/Login/Login", ([FromQuery] int loginType, [FromQuery] int userId, [FromQuery] string token, [FromQuery] string clientIp) =>
            {
                Account? account = Account.FromToken(token);

                if (account is null)
                {
                    return JsonConvert.SerializeObject(new
                    {
                        code = -1,
                        msg = "Invalid credentials!"
                    });
                }

                Player player = Player.FromId(account.Uid);

                LoginGate gate = new()
                {
                    Code = 0,
                    Ip = Common.Common.config.GameServer.Host,
                    Port = Common.Common.config.GameServer.Port,
                    Token = player.Token
                };

                string serializedObject = JsonConvert.SerializeObject(gate);
                SDKServer.log.Info(serializedObject);
                return serializedObject;
            });
        }
    }
}
