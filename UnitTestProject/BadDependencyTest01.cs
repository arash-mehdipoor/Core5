using UnitTesting;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestProject
{
    [Trait("badDependency01", "badDependency01")]
    [Collection("groupsFixture")]
    public class BadDependencyTest01
    {
        BadDependency badDependency;
        public BadDependencyTest01(ITestOutputHelper testOutputHelper, BadDependencyFixture badDependencyFixture)
        {
            badDependency = badDependencyFixture.BadDependency;
            testOutputHelper.WriteLine(badDependency.Id);
        }

        [Fact]
        public void TestBadDependency01()
        {
            Assert.True(badDependency.True());
        }
        [Fact]
        public void TestBadDependency02()
        {
            Assert.True(badDependency.True());
        }
        [Fact]
        public void TestBadDependency03()
        {
            Assert.True(badDependency.True());
        }
        [Fact]
        public void TestBadDependency04()
        {
            Assert.True(badDependency.True());
        }
    }
}
