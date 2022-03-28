using Components;
using Unity.Entities;
using UnityEngine;
namespace Systems
{
    public class AnimatedCharacterDeathSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity entity,ref AnimatedCharacterComponent animatorComponent, ref HealthComponent health) =>
            {
                if (health.Value <= 0)
                {
                    var animator = EntityManager.GetComponentObject<Animator>(animatorComponent.AnimatorEntity);
                    animator.SetTrigger("die");
                    EntityManager.RemoveComponent<FollowPlayerComponent>(entity);
                    EntityManager.RemoveComponent<HealthComponent>(entity);
                }
            });
        }
    }
}