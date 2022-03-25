using Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine.Rendering;

namespace Systems
{
    public partial class BulletDamageSystem : SystemBase
    {
        struct CollisionEventSystemsJob : ITriggerEventsJob
        {
            public ComponentDataFromEntity<BulletComponent> bulletRef;
            public ComponentDataFromEntity<HealthComponent> healthRef;
            public void Execute(TriggerEvent triggerEvent)
            {
                Entity hitEntity, bulletEntity;
                if (bulletRef.HasComponent(triggerEvent.EntityA))
                {
                    hitEntity = triggerEvent.EntityB;
                    bulletEntity = triggerEvent.EntityA;
                }
                else if (bulletRef.HasComponent(triggerEvent.EntityB))
                {
                    hitEntity = triggerEvent.EntityA;
                    bulletEntity = triggerEvent.EntityB;
                }
                else
                    return;

                var bullet = bulletRef[bulletEntity];
                bullet.Destroyed = true;
                bulletRef[bulletEntity] = bullet;

                if (healthRef.HasComponent(hitEntity))
                {
                    var health = healthRef[hitEntity];
                    health.Value--;
                    healthRef[hitEntity] = health;
                }
            }
        }
        
        //buildWorld not required
        StepPhysicsWorld stepPhysicsWorld;
        EndSimulationEntityCommandBufferSystem endSimulationCommandBuffer;

        protected override void OnCreate()
        
        {
            stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
            endSimulationCommandBuffer = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }
        
        protected override void OnUpdate()
        {
            var job = new CollisionEventSystemsJob();
            job.bulletRef = GetComponentDataFromEntity<BulletComponent>(isReadOnly: false);
            job.healthRef = GetComponentDataFromEntity<HealthComponent>(isReadOnly: false);
            
            //Now Job.Schedule is deprecated 
            var commandBuffer = endSimulationCommandBuffer.CreateCommandBuffer().AsParallelWriter();
            Entities.ForEach((Entity entity, int entityInQueryIndex,ref BulletComponent bullet) =>
            {
                if (bullet.Destroyed)
                    commandBuffer.DestroyEntity(entityInQueryIndex, entity);
            }).ScheduleParallel();
            
            Dependency = job.Schedule(stepPhysicsWorld.Simulation, Dependency);
            endSimulationCommandBuffer.AddJobHandleForProducer(Dependency);
        }
    }
}