using Kompas6API5;

namespace TrafficConeBuilder.Builder
{
    /// <summary>
    /// Определяет абстракцию для классов построения дорожного конуса
    /// </summary>
    public interface IComponentBuilder
    {
        /// <summary>
        /// Выполнить построение модели 
        /// </summary>
        /// <param name="document3D">интерфейс активного документа компаса</param>
        /// <param name="parameters">список параметров модели</param>
        void Build(ksDocument3D document3D, Parameters.Parameters parameters);
    }
}