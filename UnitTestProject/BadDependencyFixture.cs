using System;
using UnitTesting;
using Xunit;

namespace UnitTestProject
{
    public class BadDependencyFixture : IDisposable
    {
        public BadDependency BadDependency { get; set; }
        public BadDependencyFixture()
        {
            BadDependency = new BadDependency();
        }

        public void Dispose()
        {
           
        }
    }

    [CollectionDefinition("groupsFixture")]
    public class BadDependencyFixtureCollectionFuxture:ICollectionFixture<BadDependencyFixture>
    {

    }
}
