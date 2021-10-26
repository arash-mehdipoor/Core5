using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestProject
{

    [Trait("badDependency", "badDependency")]
    public class BadDependencyTest:IClassFixture<BadDependencyFixture>
    {
        BadDependency badDependency;
        public BadDependencyTest(ITestOutputHelper testOutputHelper, BadDependencyFixture badDependencyFixture)
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
