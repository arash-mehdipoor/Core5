using UnitTesting;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestProject
{
    [Trait("badDependency02", "badDependency02")]
    [Collection("groupsFixture")]
    public class BadDependencyTest02
    {
        BadDependency badDependency;
        public BadDependencyTest02(ITestOutputHelper testOutputHelper, BadDependencyFixture badDependencyFixture)
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
