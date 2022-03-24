using Unity.Entities;

namespace Components
{
    [GenerateAuthoringComponent]
    public struct BulletPrefabComponent : IComponentData
    {
        public Entity Prefab;
        public float Speed;
    }
}