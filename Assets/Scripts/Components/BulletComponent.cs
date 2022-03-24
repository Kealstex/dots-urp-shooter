using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    [GenerateAuthoringComponent]
    public struct BulletComponent : IComponentData
    {
        public float3 Speed;
        public bool Destroyed;
    }
}