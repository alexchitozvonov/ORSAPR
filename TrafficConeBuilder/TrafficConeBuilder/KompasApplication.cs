using System.Collections.Generic;
using Kompas6API5;
using TrafficConeBuilder.Builder;

namespace TrafficConeBuilder
{
    /// <summary>
    /// Абстракция над <see cref="KompasObject"/> приложения
    /// </summary>
    public class KompasApplication
    {
        private readonly List<IComponentBuilder> _builders;

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="kompas">интерфейс представляющий приложение компаса</param>
        public KompasApplication(KompasObject kompas)
        {
            Kompas = kompas;
            _builders = new List<IComponentBuilder>()
            {
                new SketchBuilder(), new CircullarExtrusionBuilder()
            };
        }

        /// <summary>
        /// Интерфейс представляющий приложение компаса
        /// </summary>
        public KompasObject Kompas { get; set; }

        /// <summary>
        /// Построить дорожный конус
        /// </summary>
        /// <param name="parameters">параметры дорожного конуса</param>
        public void Build(Parameters.Parameters parameters)
        {
            var doc = (ksDocument3D)Kompas.Document3D();
            doc.Create();
            doc = (ksDocument3D)Kompas.ActiveDocument3D();

            _builders.ForEach(t => t.Build(doc, parameters));
        }
    }
}