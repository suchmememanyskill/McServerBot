namespace JevilNet.Services.Model;

public class StatusCommandPost
{
    public string Command { get; set; }
    
    public static async Task Post(string command) => await Utils.Post($"Status/command", new StatusCommandPost()
    {
        Command = command
    });
}