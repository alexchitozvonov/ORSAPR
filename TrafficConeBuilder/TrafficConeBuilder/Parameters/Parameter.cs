using System;

namespace TrafficConeBuilder.Parameters
{
    /// <summary>
    /// Характеризует один из изменяемых параметров модели
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Конструктор модели
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="max">максимальное значение</param>
        /// <param name="min">минимальное значение</param>
        /// <param name="value">значение</param>
        public Parameter(ParameterName name, double max, double min, double value)
        {
            if (max < min || max == min)
            {
                throw new ArgumentException(
                    $"{name.ToString()} containts error. Min: {min.ToString()} " +
                    $"Max: {max.ToString()}. Max does not be less min");
            }

            ValidateDouble(max);
            ValidateDouble(min);
            ValidateDouble(value);

            Name = name;
            Max = max;
            Min = min;
            Value = value;
        }

        /// <summary>
        /// Название параметра
        /// </summary>
        public ParameterName Name { get; }
        /// <summary>
        /// Максимальное значение параметра
        /// </summary>
        public double Max { get; }
        /// <summary>
        /// Минимальное значение параметра
        /// </summary>
        public double Min { get; }
        /// <summary>
        /// Значение параметра
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Проверить значение на принадлежность диапазаноу [<see cref="Min"/>..<see cref="Max"/>]
        /// </summary>
        /// <returns>
        /// если была найдена ошибка, то будет возвращена <see cref="string"/> с описанием ошибки
        /// если нет, то вернётся <see cref="string.Empty"/>
        /// </returns>
        public string CheckParameterValue()
        {
            if (Value < Min || Value > Max)
            {
                return $"{Name.ToString()} must belong to the interval [{Min.ToString()}..{Max.ToString()}]";
            }

            return string.Empty;
        }

        /// <summary>
        /// Проверка вещественного числа
        /// </summary>
        /// <param name="value">вещественное число</param>
        private void ValidateDouble(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value) || value == 0)
            {
                throw new ArgumentException($"{value.ToString()} is NaN, Infinity or equals by 0");
            }
        }
    }

    /// <summary>
    /// Имена параметров дорожного конуса
    /// </summary>
    public enum ParameterName
    {
        /// <summary>
        /// Верхнее отверстие конуса
        /// </summary>
        A,
        /// <summary>
        /// Расстояние между верхним и нижним отверстиями конуса
        /// </summary>
        B,
        /// <summary>
        /// Высота основания
        /// </summary>
        C,
        /// <summary>
        /// Диаметр нижнего отверстия
        /// </summary>
        D,
        /// <summary>
        /// Диаметр основания дна
        /// </summary>
        E
    }
}
