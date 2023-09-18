using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Baharan.Pages;

public class Index_Tests : BaharanWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
