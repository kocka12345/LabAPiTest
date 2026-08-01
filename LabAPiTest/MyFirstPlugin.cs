using System;
using CommandSystem;
using LabApi.Features;
using LabApi.Features.Console;
using LabApi.Loader.Features.Plugins;
using static LabApi.Features.Console.Logger;

namespace LabAPiTest;


public class MyFirstPlugin : Plugin
{
    // The name of the plugin
    public override string Name { get; } = "My First Plugin";

    // The description of the plugin
    public override string Description { get; } = "This plugin tests commands";

    // The author of the plugin
    public override string Author { get; } = "kocka123";

    // The current version of the plugin
    public override Version Version { get; } = new Version(1, 0, 0, 0);

    // The required version of LabAPI (usually the version the plugin was built with)
    public override Version RequiredApiVersion { get; } = new (LabApiProperties.CompiledVersion);
    
    
    public override void Enable()
    {
        Info("Hello World!");
    }


    public override void Disable()
    {
        Info("Goodbye World!");  
    }
}   

[CommandHandler(typeof(ClientCommandHandler))]
[CommandHandler(typeof(RemoteAdminCommandHandler))]
[CommandHandler(typeof(GameConsoleCommandHandler))]
public class TestCommand : ICommand
{
    public string Command { get; } = "Test"; // The command used in the console.
    public string[] Aliases { get; } = new string[] {"T"}; // The desired aliases.
    public string Description { get; } = "Test command"; // A small description.

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (arguments.Count == 0)
        {
            response = "Test run successfully, but you did not specify any arguments";
            return true; 
        }
        else
        {
            response = "This was a test " + string.Join("-", arguments); 
            Info("Test command executed - returning true!");
            return true; 
        }
        
    }
}
[CommandHandler(typeof(ClientCommandHandler))]
[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class Msg : ICommand
{
    public string Command { get; } = "MSG"; // The command used in the console.
    public string[] Aliases { get; } = new string[] {"M"}; // The desired aliases.
    public string Description { get; } = "Direct message a selected player"; // A small description.

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
       Info("Message was sent by "  + sender.LogName);
       response = "Message sent";
       return true;

    }
}