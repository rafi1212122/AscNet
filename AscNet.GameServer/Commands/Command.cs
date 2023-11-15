﻿using System.Reflection;
using System.Text.RegularExpressions;
using AscNet.Logging;

namespace AscNet.GameServer.Commands
{
    public abstract class Command
    {
        protected Session session;
        protected string[] args;

        public abstract string Help { get; }

        /// <summary>
        /// Make sure to handle me well...
        /// </summary>
        /// <param name="session"></param>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        public Command(Session session, string[] args, bool validate = true)
        {
            this.session = session;
            this.args = args;

            string? ret = Validate();
            if (ret is not null && validate)
                throw new ArgumentException(ret);
        }

        public string? Validate()
        {
            List<PropertyInfo> argsProperties = GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.GetCustomAttribute(typeof(ArgumentAttribute)) is not null).ToList();
            if (argsProperties.Count != args.Length)
                return "Invalid args length!";

            foreach (var argProp in argsProperties)
            {
                ArgumentAttribute attr = (ArgumentAttribute)argProp.GetCustomAttribute(typeof(ArgumentAttribute))!;
                if (!attr.Pattern.IsMatch(args[attr.Position]))
                    return $"Argument {argProp.Name} is invalid!";

                argProp.SetValue(this, args[attr.Position]);
            }
            return null;
        }

        public abstract void Execute();
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ArgumentAttribute : Attribute
    {
        public int Position { get; }
        public Regex Pattern { get; }
        public string? Description { get; }

        public ArgumentAttribute(int position, string pattern, string? description = null)
        {
            Position = position;
            Pattern = new(pattern);
            Description = description;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CommandNameAttribute : Attribute
    {
        public string Name { get; }

        public CommandNameAttribute(string name)
        {
            Name = name;
        }
    }

    [CommandName("help")]
    internal class HelpCommand : Command
    {
        public HelpCommand(Session session, string[] args, bool validate = true) : base(session, args, validate) { }

        public override string Help => "Show this help.";

        public override void Execute()
        {
            string helpText = string.Empty;

            foreach (var command in CommandFactory.commands.Keys)
            {
                Command? cmd = CommandFactory.CreateCommand(command, session, args, false);
                if (cmd is not null)
                    helpText += $"{command}\n\t└─{cmd.Help}\n";
            }
        }
    }

    public static class CommandFactory
    {
        public static readonly Dictionary<string, Type> commands = new();

        internal static readonly Logger log = new(typeof(CommandFactory), LogLevel.DEBUG, LogLevel.DEBUG);
        
        public static void LoadCommands()
        {
            log.LogLevelColor[LogLevel.INFO] = ConsoleColor.White;
            log.Info("Loading commands...");

            IEnumerable<Type> classes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                        where t.IsClass && t.GetCustomAttribute<CommandNameAttribute>() is not null
                                        select t;

            foreach (var command in classes)
            {
                CommandNameAttribute nameAttr = command.GetCustomAttribute<CommandNameAttribute>()!;
                commands.Add(nameAttr.Name, command);
#if DEBUG
                log.Info($"Loaded {nameAttr.Name} command");
#endif
            }

            log.Info("Finished loading commands");
        }

        public static Command? CreateCommand(string name, Session session, string[] args, bool validate = true)
        {
            Type? command = commands.GetValueOrDefault(name);
            if (command is null)
                return null;

            return (Command)Activator.CreateInstance(command, new object[] { session, args, validate })!;
        }
    }
}