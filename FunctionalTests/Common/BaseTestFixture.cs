namespace FunctionalTests.Common;

using static FunctionalTests.Testing;

[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }
}
