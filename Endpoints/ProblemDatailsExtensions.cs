using Flunt.Notifications;

namespace ProductProject.Endpoints;

public static class ProblemDatailsExtensions
{
    //Foi preciso usar o THIS serve para fazer com que o método que criamos "ConvertToProblemDetails" fizesse parte do Notification
    public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications
                .GroupBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
    } 
}
