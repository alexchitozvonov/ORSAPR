using Kompas6API5;
using Kompas6Constants3D;
using TrafficConeBuilder.Parameters;

namespace TrafficConeBuilder.Builder
{
    /// <inheritdoc />
    /// <summary>
    ///     Представляет метод для выполнения выреза по сечениям
    /// </summary>
    public class CutBuilder : IComponentBuilder
    {
        /// <inheritdoc />
        public void Build(ksDocument3D document3D, Parameters.Parameters parameters)
        {
            var part = (ksPart) document3D.GetPart((short) Part_Type.pTop_Part);
            var zxPlane = (ksEntity) part.GetDefaultEntity((short) Obj3dType.o3d_planeXOZ);

            var entityOffsetPlane = (ksEntity) part.NewEntity((short) Obj3dType.o3d_planeOffset);
            var planeOffsetDefinition = (ksPlaneOffsetDefinition)
                entityOffsetPlane.GetDefinition();
            planeOffsetDefinition.direction = false;
            planeOffsetDefinition.offset = parameters[ParameterName.B];
            planeOffsetDefinition.SetPlane(zxPlane);
            entityOffsetPlane.Create();

            var D = parameters[ParameterName.D];
            var A = parameters[ParameterName.A];
            var thikness = parameters[ParameterName.WallThikness];
            var firstSketch = CreateCircleSketch(part, zxPlane,
                D / 2 - thikness / 2);
            var secondSketch = CreateCircleSketch(part, entityOffsetPlane,
                A / 2 - thikness / 2);

            var cutLoft = (ksEntity) part.NewEntity((short) Obj3dType.o3d_cutLoft);
            var baseLoftDefinition = (ksCutLoftDefinition) cutLoft.GetDefinition();
            baseLoftDefinition.SetLoftParam(false, true, true);
            var sketches = (ksEntityCollection) baseLoftDefinition.Sketchs();
            sketches.Clear();
            sketches.Add(firstSketch);
            sketches.Add(secondSketch);
            cutLoft.Create();
        }

        /// <summary>
        ///     Операция построения окружности
        /// </summary>
        /// <param name="part">3D-модель компаса</param>
        /// <param name="plane">плоскость на которой строить окружность</param>
        /// <param name="radius">радиус окружности</param>
        /// <returns></returns>
        private ksEntity CreateCircleSketch(ksPart part, ksEntity plane, double radius)
        {
            var currentPlane = plane;
            var sketch = (ksEntity) part.NewEntity((short) Obj3dType.o3d_sketch);
            var sketchDefinition = (ksSketchDefinition) sketch.GetDefinition();
            sketchDefinition.SetPlane(currentPlane);

            sketch.Create();
            var sketchEdit = (ksDocument2D) sketchDefinition.BeginEdit();
            sketchEdit.ksCircle(0, 0, radius, 1);
            sketchDefinition.EndEdit();

            return sketch;
        }
    }
}