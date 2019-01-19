using Kompas6API5;
using Kompas6Constants3D;
using TrafficConeBuilder.Parameters;

namespace TrafficConeBuilder.Builder
{
    /// <inheritdoc />
    /// <summary>
    /// Представляет метод для построения эскзина дорожного конуса
    /// </summary>
    public class SketchBuilder : IComponentBuilder
    {
        /// <inheritdoc />
        public void Build(ksDocument3D document3D, Parameters.Parameters parameters)
        {
            var part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);
            var currentPlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);

            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            var sketchDefinition = (ksSketchDefinition)entitySketch.GetDefinition();
            sketchDefinition.SetPlane(currentPlane);
            entitySketch.Create();

            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();

            var E = parameters[ParameterName.E];
            var C = parameters[ParameterName.C];
            var D = parameters[ParameterName.D];
            var A = parameters[ParameterName.A];
            var B = parameters[ParameterName.B];
            sketchEdit.ksLineSeg(0, 0, E / 2, 0, 1);
            sketchEdit.ksLineSeg(E / 2, 0, E / 2, C, 1);
            sketchEdit.ksLineSeg(E / 2, C, D / 2, C, 1);
            sketchEdit.ksLineSeg(D / 2, C, A / 2, B, 1);
            sketchEdit.ksLineSeg(A / 2, B, 0, B, 1);
            sketchEdit.ksLineSeg(0, B, 0, 0, 1);
            sketchEdit.ksLineSeg(0, -2, 0, 16, 3);
            sketchDefinition.EndEdit();
        }
    }
}