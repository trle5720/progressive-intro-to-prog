namespace Shows.Api.Shows;

// The watch desk is another team's service. When a show is added, they want to know.
// We depend on the interface so a test can stand in for it without making a real call.
public interface INotifyInventoryControl
{
    Task NotifyNewShowAsync(ShowSummary show);
}

public class InventoryNotification(HttpClient client) : INotifyInventoryControl
{
    public async Task NotifyNewShowAsync(ShowSummary show)
    {
        
        var response = await client.PostAsJsonAsync("/notifications", new { show.Id, show.Title });
        response.EnsureSuccessStatusCode(); // blow up if the status code is  not 200-299
    }
}
