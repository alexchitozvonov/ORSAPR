using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TrafficConeBuilder.Parameters;

namespace UnitTests.TrafficConeBuilder.Tests
{
    [TestFixture()]
    public class ParametersTests
    {
        [Test(Description = "Проверка работы конструктора объектов " +
                            "при передаче корректного аргумента")]
        public void ConstructorAndPropertiesPositiveTest()
        {
            var a = new Parameter(ParameterName.A, 100, 10, 25);
            var b = new Parameter(ParameterName.B, 100, 10, 25);
            var c = new Parameter(ParameterName.C, 100, 10, 25);
            var d = new Parameter(ParameterName.D, 100, 10, 25);
            var e = new Parameter(ParameterName.E, 100, 10, 25);
            var parameterList = new List<Parameter>()
            {
                a, b, c, d, e
            };
            var parameters = new Parameters(parameterList);

            Assert.NotNull(parameters);
            Assert.AreEqual(a.Value, parameters[ParameterName.A]);
            Assert.AreEqual(b.Value, parameters[ParameterName.B]);
            Assert.AreEqual(c.Value, parameters[ParameterName.C]);
            Assert.AreEqual(d.Value, parameters[ParameterName.D]);
            Assert.AreEqual(e.Value, parameters[ParameterName.E]);
        }

        [Test(Description = "Проверка работы конструктора объектов " +
                            "при передаче некорректного аргумента")]
        public void ConstructorNegativeTests()
        {
            var a = new Parameter(ParameterName.A, 100, 10, 25);
            var b = new Parameter(ParameterName.B, 100, 10, 25);
            var c = new Parameter(ParameterName.C, 100, 10, 25);
            var d = new Parameter(ParameterName.D, 100, 10, 25);
            var e = new Parameter(ParameterName.E, 100, 10, 25);

            Assert.Throws<ArgumentNullException>(() => 
            {
                var parameters = new Parameters(null);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var parameters = new Parameters(new List<Parameter>());
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var parameters = new Parameters(new List<Parameter>()
                {
                    a, b, c, null, e
                });
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var parameters = new Parameters(new List<Parameter>()
                {
                    a, a, c, d, e
                });
            });
        }

        [Test(Description = "Проверка работы метода при инициализации " +
                            "объекта корректными значениями")]
        public void CheckAllParametersValuePositiveTests()
        {
            var a = new Parameter(ParameterName.A, 100, 10, 25);
            var b = new Parameter(ParameterName.B, 100, 10, 25);
            var c = new Parameter(ParameterName.C, 100, 10, 25);
            var d = new Parameter(ParameterName.D, 100, 10, 25);
            var e = new Parameter(ParameterName.E, 100, 10, 25);
            var parameterList = new List<Parameter>()
            {
                a, b, c, d, e
            };
            var parameters = new Parameters(parameterList);
            var result = parameters.CheckAllParametersValue();

            Assert.AreEqual(true, result.All(string.IsNullOrEmpty));
        }

        [Test(Description = "Проверка работы метода при инициализации " +
                            "объекта некорректными значениями")]
        public void CheckAllParametersValueNegativeTests()
        {
            var a = new Parameter(ParameterName.A, 100, 50, 110);
            var b = new Parameter(ParameterName.B, 100, 20, 25);
            var c = new Parameter(ParameterName.C, 100, 10, 25);
            var d = new Parameter(ParameterName.D, 100, 10, 25);
            var e = new Parameter(ParameterName.E, 100, 10, 25);
            var parameterList = new List<Parameter>()
            {
                a, b, c, d, e
            };
            var parameters = new Parameters(parameterList);
            var result = parameters.CheckAllParametersValue();

            Assert.AreEqual(false, result.All(string.IsNullOrEmpty));
        }
    }
}