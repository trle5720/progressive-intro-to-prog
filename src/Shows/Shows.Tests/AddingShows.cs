using Alba;
using NSubstitute;
using Shows.Api.Shows;

namespace Shows.Tests;

public class AddingShows(ShowsApiFixture fixture) : IClassFixture<ShowsApiFixture>
{
    [Fact]
    public async Task AddedShowShowsUpInTheList()
    {
       var newShow = new { title = "Twin Peaks: The Return", genre = "Drama" };
       // var newShow = new ShowCreateRequest { Name = "Twin Peaks: The Return", Genre = "Drama" };

        // This is NOT a Unit test, because it IS hitting the network, using a database, etc.
        // This is either a System Test, or a Unit Integration Test (I'll explain the difference later)
        await fixture.Host.Scenario(api =>
        {
            api.Post.Json(newShow).ToUrl("/shows");
            api.StatusCodeShouldBe(201);
        });

        var response = await fixture.Host.Scenario(api =>
        {
            api.Get.Url("/shows");
            api.StatusCodeShouldBeOk();
        });

        var shows = response.ReadAsJson<IReadOnlyList<ShowSummary>>();
        Assert.NotNull(shows);
        Assert.Contains(shows, s => s.Title == "Twin Peaks: The Return");
    }

    [Fact]
    public async Task AddingAShowNotifiesTheWatchDesk()
    {
        var newShow = new { title = "The Leftovers", genre = "Drama" };

        await fixture.Host.Scenario(api =>
        {
            api.Post.Json(newShow).ToUrl("/shows");
            api.StatusCodeShouldBe(201);
        });

        await fixture.Notifier.Received().NotifyNewShowAsync(Arg.Is<ShowSummary>(s => s!.Title == "The Leftovers"));
    }
}
