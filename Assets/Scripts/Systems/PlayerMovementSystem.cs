using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;


namespace Systems
{
    //ComponentSystem - main thread (single) script
    public class PlayerMovementSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {

            float deltaTime = UnityEngine.Time.deltaTime;
            float2 input = new float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            //search all entities with this include component
            //ref for best perfomance and speed reference to this data 
            // ref value - it's reference on value of the array Unity in memory
            //Unity.Mathematics - best perfomance.
            Entities.ForEach((ref PlayerComponent player, ref LocalToWorld transform, ref PhysicsVelocity velocity)
                =>
            {
                //Input value - [-1,1]
                //Forward vector - is unit vector
                float3 dir = transform.Forward * input.y * player.MovementSpeed * deltaTime;
                //movement speed + direction vector
                dir.x += input.x * player.MovementSpeed * deltaTime;
                velocity.Linear += new float3(dir.x, 0f, dir.z);
                //spin around speed 
                velocity.Angular = new float3(0f, input.x * player.RotationSpeed * deltaTime, 0f);
            });
        }
    }
}
