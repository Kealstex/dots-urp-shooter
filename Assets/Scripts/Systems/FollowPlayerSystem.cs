using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.AI;

namespace Systems
{
    public class FollowPlayerSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            float3 targetPosition = float3.zero;
            Entities.ForEach((Entity entity, ref LocalToWorld transform, ref FollowTargetComponent tag) =>
            {
                targetPosition = transform.Position;
            });
            
            Entities.ForEach((Entity entity, ref NavMeshAgentComponent agent, ref Parent parent) =>
            {
                var isDeathAgent = !EntityManager.HasComponent<FollowPlayerComponent>(parent.Value);
                var navMeshAgent = EntityManager.GetComponentObject<NavMeshAgent>(entity);
                if (navMeshAgent != null && !isDeathAgent)
                {
                    navMeshAgent.SetDestination(targetPosition);
                    EntityManager.SetComponentData(agent.MoveEntity, new Translation{ Value = navMeshAgent.transform.position});
                }
            });
        }
    }
}