namespace JevilNet.Services.Model;

public class StatusKillPost
{
    public static async Task Post() => await Utils.Post($"Status/kill", new StatusKillPost());
}