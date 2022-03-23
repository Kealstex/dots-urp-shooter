using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

namespace Systems
{
    public partial class FreezeVerticalRotationSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .ForEach((ref FreezeVerticalRotationComponent freezeTag, ref PhysicsMass mass) =>
                {
                    mass.InverseInertia.xz = new float2(0.0f, 0.0f);
                })
                .ScheduleParallel();
        }
    }
}