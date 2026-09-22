using Alba;
using Shows.Api.Shows;

namespace Shows.Tests;

public class ListingShows(ShowsApiFixture fixture) : IClassFixture<ShowsApiFixture>
{
    [Fact]
    public async Task CanGetASingleShowThatExists()
    {
        // Add one, then read it back by the id we were handed.
        var created = await fixture.Host.Scenario(api =>
        {
            api.Post.Json(new { title = "Severance", genre = "Sci-Fi" }).ToUrl("/shows");
            api.StatusCodeShouldBe(201);
        });

        var added = created.ReadAsJson<ShowDetails>();
        Assert.NotNull(added);

        var fetched = await fixture.Host.Scenario(api =>
        {
            api.Get.Url($"/shows/{added.Id}");
            api.StatusCodeShouldBeOk();
        });

        var show = fetched.ReadAsJson<ShowDetails>();
        Assert.NotNull(show);
        Assert.Equal("Severance", show.Title);
        Assert.Equal("Sci-Fi", show.Genre);
    }

    [Fact]
    public async Task NonGuidReturns404()
    {
        await fixture.Host.Scenario(api =>
        {
            api.Get.Url($"/shows/9b3ea5f2-e43b-44d0-83f3-e2d97");
            api.StatusCodeShouldBe(404);
        });
    }

    // 6b72e68d-e596-4e11-a190-bedbded40cc2
    [Fact]
    public async Task IfItIsNotFoundYouGetA404()
    {
        await fixture.Host.Scenario(api =>
        {
            api.Get.Url($"/shows/6b72e68d-e596-4e11-a190-bedbded40cc2");
            api.StatusCodeShouldBe(404);
        });
    }
}
