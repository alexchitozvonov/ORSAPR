using Kompas6API5;
using Kompas6Constants3D;
using TrafficConeBuilder.Parameters;

namespace TrafficConeBuilder.Builder
{
    /// <inheritdoc/>
    /// <summary>
    /// Представляет метод для построения фаски или скругления основания конуса
    /// </summary>
    public class ChamferOrFilletBuilder : IComponentBuilder
    {
        /// <inheritdoc />
        public void Build(ksDocument3D document3D, Parameters.Parameters parameters)
        {
            var extendFeatureParameter = parameters.GetExtendFeatureValue();
            var part = (ksPart) document3D.GetPart((short) Part_Type.pTop_Part);

            switch (extendFeatureParameter.Name)
            {
                case ParameterName.Chamfer:
                    CreateChamfer(part, extendFeatureParameter.Value);
                    break;
                case ParameterName.Fillet:
                    CreateFillet(part, extendFeatureParameter.Value);
                    break;
            }
        }

        /// <summary>
        /// Построить фаску
        /// </summary>
        /// <param name="part">3D-модель компаса</param>
        /// <param name="radius">радиус фаски</param>
        private void CreateChamfer(ksPart part, double radius)
        {
            var entityChamfer = (ksEntity) part.NewEntity((short) Obj3dType.o3d_chamfer);
            var chamferDefinition = (ksChamferDefinition) entityChamfer.GetDefinition();
            chamferDefinition.SetChamferParam(true, radius, radius);
            chamferDefinition.tangent = false;
            var entityCollectionPart = (ksEntityCollection) part.
                EntityCollection((short) Obj3dType.o3d_face);
            var entityCollectionChamfer = (ksEntityCollection) chamferDefinition.array();
            entityCollectionChamfer.Clear();
            entityCollectionChamfer.Add(entityCollectionPart.GetByIndex(2));
            entityChamfer.Create();
        }

        /// <summary>
        /// Создать скругление
        /// </summary>
        /// <param name="part">3D-модель компаса</param>
        /// <param name="radius">радиус скругления</param>
        private void CreateFillet(ksPart part, double radius)
        {
            var entityFillet = (ksEntity) part.NewEntity((short) Obj3dType.o3d_fillet);
            var filletDefinition = (ksFilletDefinition) entityFillet.GetDefinition();
            filletDefinition.radius = radius;
            filletDefinition.tangent = false;
            var entityCollectionPart = (ksEntityCollection) part.EntityCollection((short) Obj3dType.o3d_face);
            var entityCollectionFillet = (ksEntityCollection) filletDefinition.array();
            entityCollectionFillet.Clear();
            entityCollectionFillet.Add(entityCollectionPart.GetByIndex(2));
            entityFillet.Create();
        }
    }
}