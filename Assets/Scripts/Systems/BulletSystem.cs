using Components;
using Unity.Entities;
using Unity.Physics;
namespace Systems
{
    public partial class BulletSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref BulletComponent bullet, ref PhysicsVelocity velocity) =>
            {
                velocity.Linear = bullet.Speed;
            }).ScheduleParallel();
        }
    }
}