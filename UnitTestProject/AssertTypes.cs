using Session10.UnitTesting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestProject
{
    public class AssertTypes
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AssertTypes(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        

        [Fact]
        [Trait("cat1", "bool")]
        public void Assert_True()
        {
            Assert.True(true);
        }

        [Fact]
        [Trait("cat1", "bool")]
        public void Assert_False()
        {
            Assert.False(false);
        }

        [Fact]
        [Trait("cat2", "string")]
        public void Asserst_String()
        {
            string str1 = "abcd";
            string str2 = "ab";
            string str3 = "abcd";

            _testOutputHelper.WriteLine("Equal Test");
            Assert.Equal(str1, str3);

            _testOutputHelper.WriteLine("StartsWith Test");
            Assert.StartsWith(str2, str1);

            _testOutputHelper.WriteLine("EndsWith Test");
            Assert.EndsWith(str1, str3);

            Assert.Contains(str2, str3);

            //Regex
            //Assert.Matches();
        }

        [Fact]
        [Trait("cat3", "int")]
        public void Asserst_Numbers()
        {
            int num1 = 100;
            int num2 = 150;
            int num3 = 400;
            int num4 = 100;

            Assert.Equal(num1, num4);
            Assert.NotEqual(num2, num3);
            Assert.InRange(num2, num1, num3);
            Assert.NotInRange(num1, num2, num3);
        }

        [Fact]
        [Trait("cat4", "objects")]
        public void Asserst_Objects()
        {
            Product nullProduct = null;
            
            Product productNotNull = new Product();
            
            object product = new Product();
            
            object NotTypeProduct = new Customers();
            
            var store = new Store();
            
            var sameStore = store;

            var notSameStore = new Store();

            Assert.Null(nullProduct);
            Assert.NotNull(productNotNull);
            Assert.IsType<Product>(product);
            Assert.IsNotType<Product>(NotTypeProduct);
            Assert.IsAssignableFrom<IStore>(store);
            Assert.Same(store, sameStore);
            Assert.NotSame(store, notSameStore);
        }

        [Fact]
        [Trait("cat5", "Collection")]
        public void Assert_Collection()
        {
            //Assert.Contains();
            //Assert.DoesNotContain();
            //Assert.Equal();
            //Assert.All();
        }

        [Fact(Skip ="Product owner disable it")]
        [Trait("cat6", "Collection")]
        public void Assert_Exception()
        {
            var stringHelper = new StringHelper();
            Assert.Throws<Exception>(() => stringHelper.ToInt("fgh"));
        }
    }
}
