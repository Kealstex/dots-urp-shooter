using Components;
using MonoBehaviours;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public class PlayerShootingSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            if (!Input.GetButtonDown("Fire1"))
                return;
            
            Entities.ForEach((Entity entity, ref BulletPrefabComponent bullet) =>
            {
                var shooter = EntityManager.GetComponentObject<ShooterMonoBeh>(entity);
                if (shooter==null)
                    Debug.LogError("BulletPrefabComponent is missing Shooter Component");
                else
                {
                    Entity bulletPrefab = EntityManager.Instantiate(bullet.Prefab);
                    EntityManager.SetComponentData(bulletPrefab, new Translation{Value = shooter.gunHole.position});
                    EntityManager.SetComponentData(bulletPrefab, new Rotation{Value = shooter.gunHole.rotation});
                    EntityManager.AddComponentData(bulletPrefab,
                        new BulletComponent {Speed = shooter.gunHole.forward * bullet.Speed});
                }
            });
        }
    }
}