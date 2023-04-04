using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace FutApp.Pages;

public class Index_Tests : FutAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
