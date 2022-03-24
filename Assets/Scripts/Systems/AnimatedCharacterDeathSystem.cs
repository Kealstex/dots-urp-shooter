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
                    Debug.Log("SetAnimation");
                    var animator = EntityManager.GetComponentObject<Animator>(animatorComponent.AnimatorEntity);
                    animator.SetTrigger("die");
                    EntityManager.RemoveComponent<HealthComponent>(entity);
                }
            });
        }
    }
}