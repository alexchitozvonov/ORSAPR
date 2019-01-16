using Kompas6API5;
using Kompas6Constants3D;

namespace TrafficConeBuilder.Builder
{
    /// <inheritdoc />
    /// <summary>
    /// Представляет метод для выполнения кругового выдавливания
    /// </summary>
    public class CircullarExtrusionBuilder : IComponentBuilder
    {
        /// <inheritdoc />
        public void Build(ksDocument3D document3D, Parameters.Parameters parameters)
        {
            var part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);

            var entityRotated =
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_baseRotated);
            var entityRotatedDefinition =
                (ksBaseRotatedDefinition)entityRotated.GetDefinition();

            entityRotatedDefinition.directionType = 0;
            entityRotatedDefinition.SetSideParam(true, 360);
            entityRotatedDefinition.SetSketch(part.GetObjectByName("Эскиз:1", 5, false, false));
            entityRotated.Create();
        }
    }
}