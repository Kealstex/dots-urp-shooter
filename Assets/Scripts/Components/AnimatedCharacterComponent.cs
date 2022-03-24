using Unity.Entities;
namespace Components
{
    [GenerateAuthoringComponent]
    public struct AnimatedCharacterComponent : IComponentData
    {
        public Entity AnimatorEntity;
    }
}