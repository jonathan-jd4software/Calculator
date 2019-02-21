using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Extensions;

namespace Calculator.Tests.Extensions
{
    [TestFixture]
    public class DoubleExtensions_TestFixture
    {

        [Test]
        public void ShouldTruncateToEight()
        {
            // Arrange
            double val = 123.123456789;

            // Act
            double res = val.Truncate(8);

            // Assert
            Assert.AreEqual(123.12345678, res);
        }




        [Test]
        public void ShouldTruncateToSix()
        {
            // Arrange
            double val = 123.123456789;

            // Act
            double res = val.Truncate(6);

            // Assert
            Assert.AreEqual(123.123456, res);
        }


        [Test]
        public void ShouldTruncateToFour()
        {
            // Arrange
            double val = 123.123456789;

            // Act
            double res = val.Truncate(4);

            // Assert
            Assert.AreEqual(123.1234, res);
        }

    }
}
