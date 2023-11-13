using AscNet.Common.Database;
using AscNet.GameServer;
using AscNet.GameServer.Commands;
using AscNet.SDKServer.Models ;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AscNet.SDKServer.Controllers
{
    public class CommandController : IRegisterable
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/api/AscNet/commands", (HttpContext ctx) =>
            {
                List<object> commands = new();

                foreach (var command in CommandFactory.commands.Keys)
                {
                    Command? cmd = CommandFactory.CreateCommand(command, null!, Array.Empty<string>(), false);
                    if (cmd is not null)
                        commands.Add(new
                        {
                            name = command,
                            help = cmd.Help
                        });
                }

                return ctx.Response.WriteAsync(JsonConvert.SerializeObject(new { code = 0, msg = "OK", data = commands }));
            });

            app.MapPost("/api/AscNet/command/{command}", ([FromHeader] string authorization, [FromBody] ExecuteCommandBody body, string command, HttpContext ctx) =>
            {
                Player? player = Player.FromToken(authorization);
                if (player is null)
                {
                    ctx.Response.StatusCode = 401;
                    return ctx.Response.WriteAsync(JsonConvert.SerializeObject(new { msg = "Invalid token!" }));
                }

                Session? session = Server.Instance.SessionFromUID(player.PlayerData.Id);
                if (session is null)
                {
                    ctx.Response.StatusCode = 400;
                    return ctx.Response.WriteAsync(JsonConvert.SerializeObject(new { msg = "Player is offline!" }));
                }

                try
                {
                    Command? cmd = CommandFactory.CreateCommand(command, session, body.Args);
                    if (cmd is null)
                    {
                        ctx.Response.StatusCode = 404;
                        return ctx.Response.WriteAsync(JsonConvert.SerializeObject(new { msg = "Command does not exists!" }));
                    }

                    cmd.Execute();
                }
                catch (Exception ex)
                {
                    ctx.Response.StatusCode = 400;
                    return ctx.Response.WriteAsync(JsonConvert.SerializeObject(new { msg = "Execution error!", err = ex.InnerException?.Message ?? ex.Message }));
                }

                return ctx.Response.WriteAsync(JsonConvert.SerializeObject(new { msg =  "OK" }));
            });
        }
    }
}
