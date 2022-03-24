using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;

namespace Systems
{
    public partial class AnimatorCharacterSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref AnimatedCharacterComponent character, ref PhysicsVelocity velocity) =>
            {
                var animator = EntityManager.GetComponentObject<Animator>(character.AnimatorEntity);
                animator.SetFloat("speed", math.length(velocity.Linear));
            });
        }
    }
}