using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using LambdaUnitTestExample;

namespace LambdaUnitTestExample.Tests
{
    public class CarTest
    {
        [Fact]
        public void TestConstructor()
        {
            // Hint: Conditions is an enum.
            Car car = new Car("Chevy", Condition.EXCELLENT);

            Assert.Equal("Chevy", car.Make);
            Assert.Equal(0, car.Speed);
            Assert.Equal(Condition.EXCELLENT, car.Condition);
        }

        [Theory]
        [InlineData(Condition.EXCELLENT)]
        [InlineData(Condition.GOOD)]
        [InlineData(Condition.FAIR)]
        [InlineData(Condition.BAD)]
        public void TestConditions(Condition c)
        {
            Assert.True(Convert.ToInt32(c) >= 0);
        }

        [Fact]
        public void TestSpeed()
        {
            // Hint: Speed is a C# Property.
            Car car = new Car("Ford", Condition.BAD);
            Assert.Equal(0, car.Speed);
            car.Speed = 25;
            Assert.Equal(25, car.Speed);
            car.Speed = 200;
            Assert.Equal(200, car.Speed);
            car.Speed = 201;
            Assert.Equal(200, car.Speed);
            car.Speed = -25;
            Assert.Equal(-25, car.Speed);
            car.Speed = -50;
            Assert.Equal(-50, car.Speed);
            car.Speed = -51;
            Assert.Equal(-50, car.Speed);
        }
    }
}