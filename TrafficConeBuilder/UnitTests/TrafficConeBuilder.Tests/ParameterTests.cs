using System;
using NUnit.Framework;
using TrafficConeBuilder.Parameters;

namespace UnitTests.TrafficConeBuilder.Tests
{
    [TestFixture()]
    public class ParameterTests
    {
        [TestCase(100, 10, 25, 
            Description = "Проверка конструктора и свойств объекта " +
                          "при передаче корректных значений")]
        public void ConstructorAndPropertiesPositiveTest(double max, double min, double value)
        {
            var parameter = new Parameter(default(ParameterName), max, min, value);

            Assert.NotNull(parameter);
            Assert.AreEqual(default(ParameterName), parameter.Name);
            Assert.AreEqual(max, parameter.Max);
            Assert.AreEqual(min, parameter.Min);
            Assert.AreEqual(value, parameter.Value);
        }

        [TestCase(5, 5, 3, 
            Description = "Проверка создания объекта при передаче max == min")]
        [TestCase(5, 10, 3, 
            Description = "Проверка создания объекта при передаче max < min")]
        [TestCase(double.NaN, 10, 3, 
            Description = "Проверка создания объекта при передаче max == NaN")]
        [TestCase(5, double.NegativeInfinity, 3, 
            Description = "Проверка создания объекта при передаче min == Infinity")]
        [TestCase(5, 5, 0, 
            Description = "Проверка создания объекта при передаче value == 0")]
        public void ConstructorNegativeTests(double max, double min, double value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var parameter = new Parameter(default(ParameterName), max, min, value);
            });
        }

        [TestCase(100, 10, 110, true, Description = "Проверка работы метода при value > max")]
        [TestCase(100, 10, 8, true, Description = "Проверка работы метода при value < min")]
        [TestCase(100, 10, 25, false, Description = "Проверка работы метода " +
                                                    "при value > min и value < max")]
        public void CheckParameterValueNegativeAndPositiveTests(double max, double min, 
            double value, bool isError)
        {
            var parameter = new Parameter(default(ParameterName), max, min, value);
            var error = parameter.CheckParameterValue();

            var isEmptyError = !string.IsNullOrEmpty(error);
            Assert.AreEqual(isError, isEmptyError);
        }
    }
}