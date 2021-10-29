using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnitTesting;
using Xunit;
using Xunit.Sdk;

namespace UnitTestProject
{
    public class DDTest
    {
        [Fact]
        public void Sum01()
        {
            var input01 = 1;
            var input02 = 2;
            var expectedResult = 3;
            var calc = new Calc();

            var actulResult = calc.Sum(input01, input02);

            Assert.Equal(expectedResult, actulResult);
        }

    
        [Theory]
        //MemberData
        //[MemberData("GetData", MemberType = typeof(DDTest))]

        //MyDataAttribute
        [MyData]
        public void Sum02()
        {
            var input01 = 3;
            var input02 = 3;
            var expectedResult = 6;
            var calc = new Calc();

            var actulResult = calc.Sum(input01, input02);

            Assert.Equal(expectedResult, actulResult);
        }

        //InlineData
        [Theory]
        [InlineData(2, 5, 7)]
        [InlineData(3, 3,6)]
        [InlineData(1, 2,3)]
        public void Sum03(int input01, int input02, int expectedResult)
        {
            var calc = new Calc();

            var actulResult = calc.Sum(input01, input02);

            Assert.Equal(expectedResult, actulResult);
        }

        //MemberData
        [Theory]
        [MemberData("GetData",MemberType =typeof(DDTest))]
        public void Sum04(int input01, int input02, int expectedResult)
        {
            var calc = new Calc();

            var actulResult = calc.Sum(input01, input02);

            Assert.Equal(expectedResult, actulResult);
        }

        //MemberData
        public static List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]{3,3,6},
                new object[]{1,2,3 },
                new object[]{3,2,5 }
            };
        }
    }

    public class MyDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return new List<object[]>
            {
                new object[]{3,3,6},
                new object[]{1,2,3 },
                new object[]{3,2,5 }
            };
        }
    }


}
