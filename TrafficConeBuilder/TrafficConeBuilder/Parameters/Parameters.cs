using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TrafficConeBuilder.Parameters
{
    /// <summary>
    /// Содержит логику для управления списком параметров дорожного конуса
    /// </summary>
    public class Parameters : IEnumerable<Parameter>
    {
        private readonly List<Parameter> _parameters;

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="parameters">список параметров дорожного конуса</param>
        public Parameters(List<Parameter> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
            if (!parameters.Any())
            {
                throw new ArgumentException($"{parameters} must be contain elements");
            }
            if (parameters.Any(t => t == null))
            {
                throw new ArgumentNullException($"One or more parameter are " +
                                                 $"null in {parameters}");
            }
            if (parameters.Select(t => t.Name).
                Any(name => parameters.Select(t => t.Name).Count(o => o == name) > 1))
            {
                throw new ArgumentException("Parameter name must be unique");
            }

            _parameters = parameters;
        }

        /// <summary>
        /// Индексатор для представления <see cref="Parameter.Value"/> параметра по <see cref="ParameterName"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public double this[ParameterName name]
        {
            get
            {
                var parameter = _parameters.FirstOrDefault(t => t.Name == name);
                if (parameter == null)
                {
                    throw new InvalidOperationException($"Параметр {name.ToString()} не найден");
                }
                return parameter.Value;
            }
        }

        /// <summary>
        /// Проверить валидность всех параметров дорожного конуса
        /// </summary>
        /// <returns>список ошибок</returns>
        public IEnumerable<string> CheckAllParametersValue()
        {
            foreach (var parameter in _parameters)
            {
                yield return parameter.CheckParameterValue();
            }
        }

        /// <summary>
        /// Получить параметр фаски или скругления
        /// </summary>
        /// <returns></returns>
        public Parameter GetExtendFeatureValue()
        {
            return _parameters.FirstOrDefault(t => t.Name == ParameterName.Chamfer) ??
                   _parameters.FirstOrDefault(t => t.Name == ParameterName.Fillet);
        }

        /// <inheritdoc />
        public IEnumerator<Parameter> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}